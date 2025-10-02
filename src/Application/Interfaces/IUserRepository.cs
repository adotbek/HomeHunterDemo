using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IUserRepository
{
    Task<long> AddUserAsync(User user);
    Task UpdateUserAsync(User user);
    Task DeleteUserAsync(long id);
    Task<User?> GetByIdAsync(long id);
    Task<ICollection<User>> GetAllAsync();
    Task<User?> GetByNameAsync(string userName);
    Task<User?> GetByEmailAsync(string email);
    Task<ICollection<User>> GetByRoleIdAsync(long roleId);
    Task<User> GetByUserNameAsync(string userName);

}
