using Application.Dtos;
using Domain.Entities;

namespace Application.Mappers;

public class ImageMapper
{
    public static Image ToImageEntity (ImageCreateDto dto)
    {
        return new Image
        {
            HomeId = dto.HomeId,
            ImageUrl = dto.ImageUrl
        };
    }
    public static ImageDto ToImageDto (Image image)
    {
        return new ImageDto
        {
            Id = image.Id,
            HomeId = image.HomeId,
            ImageUrl = image.ImageUrl
        };
    }
}
