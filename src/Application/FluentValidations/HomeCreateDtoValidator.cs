using Application.Dtos;
using FluentValidation;

public class HomeCreateDtoValidator : AbstractValidator<HomeCreateDto>
{
    public HomeCreateDtoValidator(bool isUpdate = false)
    {
        if (isUpdate)
        {
            //RuleFor(x => x.Id)
            //    .GreaterThan(0).WithMessage("Invalid user ID");
        }

        RuleFor(x => x.Type)
            .NotEmpty().WithMessage("Type is required")
            .MaximumLength(100).WithMessage("Type should be less than 100 characters");

        RuleFor(x => x.Bio)
            .MaximumLength(1000).WithMessage("Bio should be less than 1000 characters")
            .When(x => !string.IsNullOrEmpty(x.Bio));

        RuleFor(x => x.Price)
            .GreaterThanOrEqualTo(0m).WithMessage("Price must be positive");

        RuleFor(x => x.OwnerNumber)
            .NotEmpty().WithMessage("Owner number is required")
            .MaximumLength(50).WithMessage("Owner number is too long");

        RuleFor(x => x.OwnerNumber)
            .Matches(@"^\+?[0-9\s\-()]{5,50}$")
            .WithMessage("Owner number format is invalid (only numbers and +, (), -, space allowed)");

        RuleFor(x => x.NumberOfRooms)
            .GreaterThan(0).WithMessage("Number of rooms must be positive");

        RuleFor(x => x.ImageUrls)
            .NotNull().WithMessage("Image URLs should not be null")
            .Must(list => list.Count <= 20).WithMessage("Image URLs cannot contain more than 20 items")
            .When(x => x.ImageUrls != null);

        RuleForEach(x => x.ImageUrls)
            .Must(url => Uri.IsWellFormedUriString(url, UriKind.Absolute))
            .WithMessage("Image URLs contain invalid links");

        RuleFor(x => x.LocationId)
            .GreaterThan(0).WithMessage("LocationId must be positive");

        RuleFor(x => x.CategoryId)
            .GreaterThan(0).WithMessage("CategoryId must be positive");
    }
}
