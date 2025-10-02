using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IRoleRepository
{
    Task<long> AddRoleAsync(Role role);
    Task UpdateRoleAsync(Role role);
    Task DeleteRoleAsync(long roleId);
    Task<Role?> GetByIdAsync(long roleId);
    Task<ICollection<Role>> GetAllAsync();
    Task<long> GetRoleIdByNameAsync(string roleName);
    Task<ICollection<User>> GetUsersByRoleAsync(long roleId);
}
