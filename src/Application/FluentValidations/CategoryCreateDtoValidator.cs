using Application.Dtos;
using FluentValidation;

public class CategoryCreateDtoValidator : AbstractValidator<CategoryDto>
{
    public CategoryCreateDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Category name is required")
            .MaximumLength(100).WithMessage("Category name must be less than 100 characters");
    }
}
