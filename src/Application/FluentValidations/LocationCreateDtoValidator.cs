using Application.Dtos;
using FluentValidation;

public class LocationCreateDtoValidator : AbstractValidator<LocationCreateDto>
{
    public LocationCreateDtoValidator()
    {
        RuleFor(x => x.Country)
            .NotEmpty().WithMessage("Country is required")
            .MaximumLength(100).WithMessage("Country must be less than 100 characters");

        RuleFor(x => x.City)
            .NotEmpty().WithMessage("City is required")
            .MaximumLength(100).WithMessage("City must be less than 100 characters");

        RuleFor(x => x.District)
            .NotEmpty().WithMessage("District is required")
            .MaximumLength(100).WithMessage("District must be less than 100 characters");

        RuleFor(x => x.Street)
            .NotEmpty().WithMessage("Street is required")
            .MaximumLength(150).WithMessage("Street must be less than 150 characters");

        RuleFor(x => x.HouseNumber)
            .MaximumLength(20).WithMessage("House number must be less than 20 characters")
            .When(x => !string.IsNullOrWhiteSpace(x.HouseNumber));

        RuleFor(x => x.ZipCode)
            .MaximumLength(20).WithMessage("Zip code must be less than 20 characters")
            .When(x => !string.IsNullOrWhiteSpace(x.ZipCode));
    }
}
