using Microsoft.AspNetCore.Mvc;

namespace BudgetAppV2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IServerAuthService serverAuthService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegister request)
    {
        var response = await serverAuthService.RegisterUser(
            new User
            {
                Email = request.Email
            },
            request.Password);

        if (!response.Success)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }
    
    [HttpPost("login")]
    public async Task<ActionResult<ServiceResponse<int>>> Login(UserLogin request)
    {
        var response = await serverAuthService.Login(request.Email, request.Password);

        if (!response.Success)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }
}