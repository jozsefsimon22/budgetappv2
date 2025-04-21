using Shared.Entities.Users;

namespace BudgetAppV2.Client.Services.AuthService;

public class ClientAuthService(HttpClient httpClient) : IClientAuthService
{
    public async Task<ServiceResponse<int>> Register(UserRegister request)
    {
        var result = await httpClient.PostAsJsonAsync<UserRegister>("api/auth/register", request);
        
        return await result.Content.ReadFromJsonAsync<ServiceResponse<int>>();
    }

    public Task<ServiceResponse<int>> Login(UserLogin request)
    {
        throw new NotImplementedException();
    }
}