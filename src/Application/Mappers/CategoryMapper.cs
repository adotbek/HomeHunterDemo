using Application.Dtos;
using Domain.Entities;

namespace Application.Mappers;

public class CategoryMapper
{
     public static Category ToCategoryEntity (CategoryDto dto)
    {
        return new Category
        {
            Id = dto.Id,
            Name = dto.Name,
        };
    }
    public static CategoryDto ToCategoryDto (Category category)
    {
        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name
        };
    }
}
