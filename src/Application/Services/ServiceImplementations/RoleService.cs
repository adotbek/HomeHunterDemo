using Application.Dtos;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Mappers;
using Domain.Entities;

namespace Application.Services;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;

    public RoleService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<long> CreateAsync(RoleCreateDto dto)
    {
        var role = RoleMapper.ToRoleEntity(dto);
        return await _roleRepository.AddRoleAsync(role);
    }

    public async Task UpdateAsync(RoleUpdateDto dto)
    {
        var role = await _roleRepository.GetByIdAsync(dto.RoleId);
        if (role == null)
            throw new Exception($"Role with id {dto.RoleId} not found");

        RoleMapper.UpdateEntity(role, dto);
        await _roleRepository.UpdateRoleAsync(role);
    }

    public async Task DeleteAsync(long roleId)
    {
        await _roleRepository.DeleteRoleAsync(roleId);
    }

    public async Task<RoleDto?> GetByIdAsync(long roleId)
    {
        var role = await _roleRepository.GetByIdAsync(roleId);
        return role == null ? null : RoleMapper.ToRoleDto(role);
    }

    public async Task<ICollection<RoleDto>> GetAllAsync()
    {
        var roles = await _roleRepository.GetAllAsync();
        return roles.Select(RoleMapper.ToRoleDto).ToList();
    }

    public async Task<long> GetRoleIdByNameAsync(string roleName)
    {
        return await _roleRepository.GetRoleIdByNameAsync(roleName);
    }

    public async Task<ICollection<UserGetDto>> GetUsersByRoleAsync(long roleId)
    {
        var users = await _roleRepository.GetUsersByRoleAsync(roleId);
        return users.Select(UserMapper.ToUserGetDto).ToList();
    }
}
