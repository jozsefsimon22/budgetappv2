namespace BudgetAppV2.Services.AuthService;

public interface IServerAuthService
{
    Task<ServiceResponse<int>> RegisterUser(User user, string password);
    Task<bool> UserExists(string email);
    Task<ServiceResponse<string>> Login(string email, string password);
}