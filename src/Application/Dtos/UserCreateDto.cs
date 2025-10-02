using Domain.Entities;

namespace Application.Dtos;

public class UserCreateDto
{
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public int Age { get; set; }
}
