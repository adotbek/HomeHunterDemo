using Application.Dtos;
using FluentValidation;

public class ImageCreateDtoValidator : AbstractValidator<ImageCreateDto>
{
    public ImageCreateDtoValidator()
    {
        RuleFor(x => x.ImageUrl)
            .NotEmpty().WithMessage("Image URL is required")
            .Must(url => Uri.IsWellFormedUriString(url, UriKind.Absolute))
            .WithMessage("Image URL must be a valid absolute URL");

        RuleFor(x => x.HomeId)
            .GreaterThan(0).WithMessage("HomeId must be a positive number");
    }
}
