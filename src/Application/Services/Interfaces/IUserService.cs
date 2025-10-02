using Application.Dtos;

namespace Application.Interfaces.Services;

public interface IUserService
{
    Task<long> CreateAsync(UserCreateDto dto);
    Task UpdateAsync(long id, UserCreateDto dto);
    Task DeleteAsync(long id);
    Task<UserGetDto?> GetByIdAsync(long id);
    Task<ICollection<UserGetDto>> GetAllAsync();
    Task<UserGetDto?> GetByNameAsync(string userName);
    Task<UserGetDto?> GetByEmailAsync(string email);
    Task<ICollection<UserGetDto>> GetByRoleIdAsync(long roleId);
    Task<UserGetDto?> LoginAsync(UserLoginDto dto);
}
