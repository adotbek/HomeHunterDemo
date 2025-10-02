using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IRefreshTokenRepository
{
    Task AddRefreshToken(RefreshToken refreshToken);
    Task GetRefreshTokenAsync(RefreshToken refreshToken);
    Task<RefreshToken?> GetRefreshTokenAsync(string refreshToken, long userId);
    Task<RefreshToken?> GetActiveTokenByUserIdAsync(long userId);
    Task RemoveRefreshTokenAsync(string token);
}
