using Application.Dtos;

namespace Application.Interfaces.Services;

public interface IRoleService
{
    Task<long> CreateAsync(RoleCreateDto dto);
    Task UpdateAsync(RoleUpdateDto dto);
    Task DeleteAsync(long roleId);
    Task<RoleDto?> GetByIdAsync(long roleId);
    Task<ICollection<RoleDto>> GetAllAsync();
    Task<long> GetRoleIdByNameAsync(string roleName);
    Task<ICollection<UserGetDto>> GetUsersByRoleAsync(long roleId);
}
