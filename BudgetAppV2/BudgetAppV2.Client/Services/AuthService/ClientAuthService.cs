using Shared.Entities.Users;

namespace BudgetAppV2.Client.Services.AuthService;

public class ClientAuthService(HttpClient httpClient) : IClientAuthService
{
    public async Task<ServiceResponse<int>> Register(UserRegister request)
    {
        var result = await httpClient.PostAsJsonAsync("api/auth/register", request);
        
        return await result.Content.ReadFromJsonAsync<ServiceResponse<int>>();
    }

    public async Task<ServiceResponse<string>> Login(UserLogin request)
    {
        var result = await httpClient.PostAsJsonAsync("api/auth/login", request);
        
        return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
    }

    public async Task<ServiceResponse<bool>> ChangePassword(UserChangePassword request)
    {
        var result = await httpClient.PostAsJsonAsync("api/auth/change-password", request.Password);
        return await result.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
    }
}