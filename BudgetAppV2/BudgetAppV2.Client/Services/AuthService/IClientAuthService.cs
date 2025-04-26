namespace BudgetAppV2.Client.Services.AuthService;

public interface IClientAuthService
{
    Task<ServiceResponse<int>> Register(UserRegister request);
    Task<ServiceResponse<string>> Login(UserLogin request);
}