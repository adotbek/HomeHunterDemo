using Application.Dtos;
using System.Security.Claims;

namespace Application.Helpers;

public interface ITokenService
{
    string GenerateToken(UserGetDto user);
    string GenerateRefreshToken();
    ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
}
