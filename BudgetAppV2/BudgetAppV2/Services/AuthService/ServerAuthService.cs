using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace BudgetAppV2.Services.AuthService;

public class ServerAuthService(DataContext dbContext, IConfiguration configuration) : IServerAuthService
{
    public async Task<ServiceResponse<int>> RegisterUser(User user, string password)
    {
        // 1. Validate input
        if (await UserExists(user.Email))
        {
            return new ServiceResponse<int>
            {
                Success = false,
                Message = "User with this email already exists."
            };
        }

        // 2. Create password hash and salt
        CreatePasswordHash(password, out var passwordHash, out var passwordSalt);

        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;

        // 3. Save user to database
        try
        {
            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync();

            return new ServiceResponse<int>
            {
                Data = user.Id,
                Success = true,
                Message = "Registration successful!"
            };
        }
        catch (DbUpdateException ex)
        {
            return new ServiceResponse<int>
            {
                Success = false,
                Message = $"Database error: {ex.InnerException?.Message ?? ex.Message}"
            };
        }
    }

    private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using var hmac = new HMACSHA512();
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
    }
    
    public async Task<bool> UserExists(string email)
    {
        return await dbContext.Users.AnyAsync(u => u.Email.ToLower().Equals(email.ToLower()));
    }

    public async Task<ServiceResponse<string>> Login(string email, string password)
    {
        var response = new ServiceResponse<string>();
        var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Email.ToLower().Equals(email.ToLower()));
        
        // 1. Find user by email
        if (user == null)
        {
            response.Success = false;
            response.Message = "User not found.";
            return response;
        }
        
        // 2. Verify password
        if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
        {
            response.Success = false;
            response.Message = "Wrong password.";
            return response;
        }
        
        // 3. Create JWT token
        response.Data = CreateToken(user);
        response.Success = true;
        response.Message = "Login successful!";
        return response;
    }

    public async Task<ServiceResponse<bool>> ChangePassword(int userId, string newPassword)
    {
        var user = await dbContext.Users.FindAsync(userId);
        if (user == null)
        {
            return new ServiceResponse<bool>
            {
                Success = false,
                Message = "User not found"
            };
        }
        CreatePasswordHash(newPassword, out var passwordHash, out var passwordSalt);
        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;
        
        await dbContext.SaveChangesAsync();

        return new ServiceResponse<bool>()
        {
            Data = true,
            Message = "Password has been changed"
        };
    }

    private static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using var hmac = new HMACSHA512(passwordSalt);
        var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        return computedHash.SequenceEqual(passwordHash);
    }
    
    private string CreateToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            // Add any additional claims you need (roles, etc.)
        };

        var appSettingsToken = configuration.GetSection("AppSettings:Token").Value;
        if (appSettingsToken is null)
            throw new Exception("AppSettings Token is null!");

        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8
            .GetBytes(appSettingsToken));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(1), 
            SigningCredentials = creds
        };
        
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}