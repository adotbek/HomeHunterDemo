using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class RoleRepository(AppDbContext _context) : IRoleRepository
{
    public async Task<long> AddRoleAsync(Role role)
    {
        await _context.Roles.AddAsync(role);
        await _context.SaveChangesAsync();
        return role.RoleId;
    }

    public async Task UpdateRoleAsync(Role role)
    {
        _context.Roles.Update(role);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteRoleAsync(long roleId)
    {
        var role = await _context.Roles.FindAsync(roleId);
        if (role != null)
        {
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<Role?> GetByIdAsync(long roleId)
    {
        return await _context.Roles
            .Include(r => r.Users)
            .FirstOrDefaultAsync(r => r.RoleId == roleId);
    }

    public async Task<ICollection<Role>> GetAllAsync()
    {
        return await _context.Roles
            .Include(r => r.Users)
            .ToListAsync();
    }

    public async Task<long> GetRoleIdByNameAsync(string roleName)
    {
        var role =  await _context.Roles
            .FirstOrDefaultAsync(r => r.Name == roleName);
        return role.RoleId;
    }

    public async Task<ICollection<User>> GetUsersByRoleAsync(long roleId)
    {
        return await _context.Users
            .Where(u => u.RoleId == roleId)
            .ToListAsync();
    }
}
