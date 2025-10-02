namespace Application.Dtos;

public class UserGetDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public string? ProfileImgUrl { get; set; }
    public string PhoneNumber { get; set; }
}
