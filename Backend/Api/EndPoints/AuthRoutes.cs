using Api.Models;
using Core.Models;
using Core.UseCases.Abstractions;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api.EndPoints;

public static class AuthRoutes
{
    public static void MapAuthRoutes(this WebApplication app)
    {
        app.MapPost("/api/auth/register", async (
            RegisterRequest request,
            UserUseCases userUseCases) =>
        {
            var existingUser = await userUseCases.GetByEmailAsync(request.Email);

            if (existingUser is not null)
            {
                return Results.BadRequest("Cet email est déjà utilisé.");
            }

            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                Password_Hash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Role = "User"
            };

            var id = await userUseCases.CreateAsync(user);

            return Results.Created($"/api/users/{id}", new { id });
        });

        app.MapPost("/api/auth/login", async (
            LoginRequest request,
            UserUseCases userUseCases,
            IConfiguration configuration) =>
        {
            var user = await userUseCases.GetByEmailAsync(request.Email);

            if (user is null)
            {
                return Results.Unauthorized();
            }

            var passwordValid = BCrypt.Net.BCrypt.Verify(
                request.Password,
                user.Password_Hash
            );

            if (!passwordValid)
            {
                return Results.Unauthorized();
            }

            var token = GenerateJwtToken(user, configuration);

            return Results.Ok(new AuthResponse
            {
                Token = token,
                Username = user.Username,
                Role = user.Role
            });
        });
    }

    private static string GenerateJwtToken(User user, IConfiguration configuration)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id_User.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role)
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!)
        );

        var credentials = new SigningCredentials(
            key,
            SecurityAlgorithms.HmacSha256
        );

        var token = new JwtSecurityToken(
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(2),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}