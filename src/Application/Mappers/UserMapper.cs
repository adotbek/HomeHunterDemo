using Application.Dtos;
using Domain.Entities;

namespace Application.Mappers;

public static class UserMapper
{
    public static UserGetDto ToUserGetDto(User user)
    {
        return new UserGetDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            SecondName = user.SecondName,
            UserName = user.UserName,
            PhoneNumber = user.PhoneNumber,
            Email = user.Email,
            Role = user.Role?.Name ?? string.Empty,
            ProfileImgUrl = user.ProfileImgUrl
        };
    }

    public static User ToUser(UserCreateDto dto, string passwordHash, string passwordSalt)
    {
        return new User
        {
            FirstName = dto.FirstName,
            SecondName = dto.SecondName,
            UserName = dto.UserName,
            PhoneNumber = dto.PhoneNumber,
            Email = dto.Email,
            Age = dto.Age,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt
        };
    }
    public static User ToUser(UserLoginDto dto, string passwordHash, string passwordSalt)
    {
        return new User
        {
            UserName = dto.UserName,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt
        };
    }
}
