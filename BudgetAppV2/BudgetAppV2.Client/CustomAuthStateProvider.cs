using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Components.Authorization;

namespace BudgetAppV2.Client;

public class CustomAuthStateProvider(ILocalStorageService localStorageService, HttpClient httpClient)
    : AuthenticationStateProvider
{
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var authToken = await localStorageService.GetItemAsStringAsync("authToken");
        httpClient.DefaultRequestHeaders.Authorization = null;

        var identity = new ClaimsIdentity();

        if (!string.IsNullOrEmpty(authToken))
        {
            try
            {
                identity = new ClaimsIdentity(ParseClaimsFromJwt(authToken), "jwt");
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", authToken.Replace("\"", ""));
            }
            catch
            {
                await localStorageService.RemoveItemAsync("authToken");
                identity = new ClaimsIdentity();
            }
        }

        var user = new ClaimsPrincipal(identity);
        var state = new AuthenticationState(user);
        NotifyAuthenticationStateChanged(Task.FromResult(state));
        return state;
    }

    private static byte[] ParseBase64WithoutPadding(string base64)
    {
        switch (base64.Length % 4)
        {
            case 2: base64 += "=="; break;
            case 3: base64 += "="; break;
        }

        return Convert.FromBase64String(base64);
    }

    private static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
        var payload = jwt.Split('.')[1];
        var jsonBytes = ParseBase64WithoutPadding(payload);
        var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

        if (keyValuePairs == null) return [];
        var claims = keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString() ?? string.Empty));
        return claims;
    }
}