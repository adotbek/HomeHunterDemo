using Application.Interfaces.Repositories;
using Core.Errors;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class RefreshTokenRepository(AppDbContext _context) : IRefreshTokenRepository
{
    public async Task AddRefreshToken(RefreshToken refreshToken)
    {
        await _context.RefreshTokens.AddAsync(refreshToken);
        await _context.SaveChangesAsync();
    }
    public async Task GetRefreshTokenAsync(RefreshToken refreshToken)
    {
        await _context.RefreshTokens.AddAsync(refreshToken);
        await _context.SaveChangesAsync();
    }

    public async Task<RefreshToken?> GetRefreshTokenAsync(string refreshToken, long userId)
    {
        return await _context.RefreshTokens
            .FirstOrDefaultAsync(rt => rt.Token == refreshToken && rt.UserId == userId && !rt.IsRevoked);
    }

    public async Task<RefreshToken?> GetActiveTokenByUserIdAsync(long userId)
    {
        return await _context.RefreshTokens
            .Where(rt => rt.UserId == userId && rt.Expires > DateTime.UtcNow && !rt.IsRevoked)
            .OrderByDescending(rt => rt.Expires)
            .FirstOrDefaultAsync();
    }

    public async Task RemoveRefreshTokenAsync(string token)
    {
        var refreshToken = await _context.RefreshTokens.FirstOrDefaultAsync(rt => rt.Token == token);
        if (refreshToken != null)
        {
            _context.RefreshTokens.Remove(refreshToken);
            await _context.SaveChangesAsync();
        }
    }
    public async Task DeleteRefreshToken(string refreshToken)
    {
        var token = await _context.RefreshTokens.FirstOrDefaultAsync(rt => rt.Token == refreshToken);
        if (token == null)
        {
            throw new EntityNotFoundException($"Refresh token not found {refreshToken}");
        }
        _context.RefreshTokens.Remove(token);
    }
}
