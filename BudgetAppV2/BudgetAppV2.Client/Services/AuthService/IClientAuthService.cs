namespace BudgetAppV2.Client.Services.AuthService;

public interface IClientAuthService
{
    Task<ServiceResponse<int>> Register(UserRegister request);
    Task<ServiceResponse<int>> Login(UserLogin request);
}