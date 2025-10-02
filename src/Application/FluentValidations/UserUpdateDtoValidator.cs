using Application.Dtos;
using FluentValidation;

public class UserUpdateDtoValidator : AbstractValidator<UserGetDto>
{
    public UserUpdateDtoValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Invalid user ID");

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required")
            .MaximumLength(100).WithMessage("First name must be less than 100 characters");

        RuleFor(x => x.SecondName)
            .NotEmpty().WithMessage("Second name is required")
            .MaximumLength(100).WithMessage("Second name must be less than 100 characters");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required")
            .Matches(@"^\+?[0-9\s\-()]{5,20}$")
            .WithMessage("Invalid phone number format");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email format");

        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("Username is required")
            .MinimumLength(3).WithMessage("Username must be at least 3 characters long")
            .MaximumLength(50).WithMessage("Username must be less than 50 characters");

    }
}
