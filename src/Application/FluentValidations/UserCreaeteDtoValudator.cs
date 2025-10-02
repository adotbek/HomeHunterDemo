using Application.Dtos;
using FluentValidation;

public class UserCreateDtoValidator : AbstractValidator<UserCreateDto>
{
    public UserCreateDtoValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required")
            .MaximumLength(100).WithMessage("First name must be less than 100 characters");

        RuleFor(x => x.SecondName)
            .NotEmpty().WithMessage("Second name is required")
            .MaximumLength(100).WithMessage("Second name must be less than 100 characters");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required")
            .Matches(@"^\+?[0-9\s\-()]{5,20}$").WithMessage("Invalid phone number format");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email format");

        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("Username is required")
            .MinimumLength(3).WithMessage("Username must be at least 3 characters long")
            .MaximumLength(50).WithMessage("Username must be less than 50 characters");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters long")
            .MaximumLength(100).WithMessage("Password must be less than 100 characters");

        RuleFor(x => x.Age)
            .GreaterThanOrEqualTo(18).WithMessage("User must be at least 18 years old");
    }
}
