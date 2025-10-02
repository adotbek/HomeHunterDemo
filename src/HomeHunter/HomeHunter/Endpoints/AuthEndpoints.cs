using Application.Dtos;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;

namespace HomeHunter.Endpoints;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/auth")
                       .WithTags("Authentication");

        group.MapPost("/signup", async (UserCreateDto dto, IAuthService service) =>
        {
            var id = await service.SignUpUserAsync(dto);
            return Results.Ok(new { UserId = id, Message = "User registered successfully" });
        })
        .WithName("SignUp");

        group.MapPost("/login", async (UserLoginDto dto, IAuthService service) =>
        {
            var response = await service.LoginUserAsync(dto);
            return Results.Ok(response);
        })
        .WithName("Login");

        group.MapPost("/refresh-token", async (RefreshRequestDto dto, IAuthService service) =>
        {
            var response = await service.RefreshTokenAsync(dto);
            return Results.Ok(response);
        })
        .WithName("RefreshToken");

        group.MapPost("/logout", async (string refreshToken, IAuthService service) =>
        {
            await service.LogOut(refreshToken);
            return Results.Ok(new { Message = "Logged out successfully" });
        })
        .WithName("Logout");

        group.MapPost("/send-code", async (string email, IAuthService service) =>
        {
            await service.EmailCodeSender(email);
            return Results.Ok(new { Message = "Confirmation code sent to email" });
        })
        .WithName("SendCode");

        group.MapPost("/confirm-code", async (string code, string email, IAuthService service) =>
        {
            var result = await service.ConfirmCode(code, email);
            return result
                ? Results.Ok(new { Message = "Email confirmed successfully" })
                : Results.BadRequest(new { Message = "Invalid confirmation code" });
        })
        .WithName("ConfirmCode");
    }
}
