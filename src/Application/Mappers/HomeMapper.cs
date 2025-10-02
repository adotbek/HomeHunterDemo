using Application.Dtos;
using Domain.Entities;

namespace Application.Mappers;

public class HomeMapper
{
    public static Home ToHomeEntity(HomeCreateDto dto)
    {
        return new Home
        {
            Bio = dto.Bio,
            Price = dto.Price,
            OwnerNumber = dto.OwnerNumber,
            Type = dto.Type,
            NumberOfRooms = dto.NumberOfRooms,
            IsAvailable = dto.IsAvailable,
            LocationId = dto.LocationId,
            CategoryId = dto.CategoryId
        };
    }
    public static Home ToHomeEntity(HomeUpdateDto dto)
    {
        return new Home
        {
            Id = dto.Id,
            Bio = dto.Bio,
            Type = dto.Type,
            Price = dto.Price,
            OwnerNumber = dto.OwnerNumber,
            NumberOfRooms = dto.NumberOfRooms,
            IsAvailable = dto.IsAvailable,
            LocationId = dto.LocationId,
            CategoryId = dto.CategoryId,
            Images = dto.ImageUrls.Select(url => new Image { ImageUrl = url, HomeId = dto.Id }).ToList()
        };
    }
    public static HomeDto ToHomeDto(Home home)
    {
        return new HomeDto
        {
            Id = home.Id,
            Bio = home.Bio,
            Type = home.Type,
            Price = home.Price,
            OwnerNumber = home.OwnerNumber,
            CategoryId = home.CategoryId,
            LocationId = home.LocationId,
            IsAvailable = home.IsAvailable,
            NumberOfRooms = home.NumberOfRooms,
            ImageUrls = home.Images?.Select(i => i.ImageUrl).ToList() ?? new List<string>()
        };
    }

}