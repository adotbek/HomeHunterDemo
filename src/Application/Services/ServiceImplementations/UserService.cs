using Application.Dtos;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Mappers;
using Core.Errors;
using Domain.Entities;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<long> CreateAsync(UserCreateDto dto)
    {
        var user = new User
        {
            FirstName = dto.FirstName,
            SecondName = dto.SecondName,
            PhoneNumber = dto.PhoneNumber,
            Email = dto.Email,
            UserName = dto.UserName,
            Age = dto.Age,
            PasswordHash = dto.Password, 
            PasswordSalt = ""            
        };

        return await _userRepository.AddUserAsync(user);
    }

    public async Task UpdateAsync(long id, UserCreateDto dto)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null)
            throw new EntityNotFoundException($"User with id {id} not found");

        user.FirstName = dto.FirstName;
        user.SecondName = dto.SecondName;
        user.PhoneNumber = dto.PhoneNumber;
        user.Email = dto.Email;
        user.UserName = dto.UserName;
        user.Age = dto.Age;

        await _userRepository.UpdateUserAsync(user);
    }

    public async Task DeleteAsync(long id)
    {
        await _userRepository.DeleteUserAsync(id);
    }

    public async Task<UserGetDto?> GetByIdAsync(long id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        return user == null ? null : UserMapper.ToUserGetDto(user);
    }

    public async Task<ICollection<UserGetDto>> GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return users.Select(UserMapper.ToUserGetDto).ToList();
    }

    public async Task<UserGetDto?> GetByNameAsync(string userName)
    {
        var user = await _userRepository.GetByNameAsync(userName);
        return user == null ? null : UserMapper.ToUserGetDto(user);
    }

    public async Task<UserGetDto?> GetByEmailAsync(string email)
    {
        var user = await _userRepository.GetByEmailAsync(email);
        return user == null ? null : UserMapper.ToUserGetDto(user);
    }

    public async Task<ICollection<UserGetDto>> GetByRoleIdAsync(long roleId)
    {
        var users = await _userRepository.GetByRoleIdAsync(roleId);
        return users.Select(UserMapper.ToUserGetDto).ToList();
    }

    public async Task<UserGetDto?> LoginAsync(UserLoginDto dto)
    {
        var user = await _userRepository.GetByUserNameAsync(dto.UserName);
        if (user.PasswordHash != dto.Password) 
            return null;

        return UserMapper.ToUserGetDto(user);
    }
}
