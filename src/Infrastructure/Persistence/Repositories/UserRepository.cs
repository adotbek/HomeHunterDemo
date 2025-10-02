using Application.Interfaces.Repositories;
using Core.Errors;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository(AppDbContext _context) : IUserRepository
{
    public async Task<long> AddUserAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user.Id;
    }

    public async Task UpdateUserAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteUserAsync(long id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user != null)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<User?> GetByIdAsync(long id)
    {
        return await _context.Users
            .Include(u => u.Role)
            .Include(u => u.RefreshTokens)
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<ICollection<User>> GetAllAsync()
    {
        return await _context.Users
            .Include(u => u.Role)
            .Include(u => u.RefreshTokens)
            .ToListAsync();
    }

    public async Task<User?> GetByNameAsync(string userName)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.UserName == userName);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<ICollection<User>> GetByRoleIdAsync(long roleId)
    {
        return await _context.Users
            .Where(u => u.RoleId == roleId)
            .ToListAsync();
    }
    public async Task<User> GetByUserNameAsync(string userName)
    {
        var user = await _context.Users.Include(_ => _.Confirmer).Include(_ => _.Role).FirstOrDefaultAsync(x => x.UserName == userName);
        if (user == null)
        {
            throw new EntityNotFoundException($"Entity with {userName} not found");
        }
        return user;
    }
}
