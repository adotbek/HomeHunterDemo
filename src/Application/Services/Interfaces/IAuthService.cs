using Application.Dtos;
using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IAuthService
{
    Task<long> SignUpUserAsync(UserCreateDto userCreateDto);
    Task<LoginResponseDto> LoginUserAsync(UserLoginDto userLoginDto);
    Task<LoginResponseDto> RefreshTokenAsync(RefreshRequestDto request);
    Task EmailCodeSender(string email);
    Task LogOut(string token);
    Task<bool> ConfirmCode(string userCode, string email);

}
