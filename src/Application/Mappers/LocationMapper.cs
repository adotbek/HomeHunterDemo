using Application.Dtos;
using Domain.Entities;

namespace Application.Mappers;

public class LocationMapper
{
    public static Location ToLocationEntity (LocationCreateDto dto)
    {
        return new Location
        {
            Country = dto.Country,
            City = dto.City,
            District = dto.District,
            Street = dto.Street,
            HouseNumber = dto.HouseNumber,
            ZipCode = dto.ZipCode,
        };
    }
    public static LocationDto ToLocationDto (Location location)
    {
        return new LocationDto
        {
            Id = location.Id,
            Country = location.Country,
            City = location.City,
            District = location.District,
            Street = location.Street,
            HouseNumber = location.HouseNumber,
            ZipCode = location.ZipCode,
        };
    }
    public static Location ToLocationEntity(LocationUpdateDto dto)
    {
        return new Location
        {
            Id = dto.Id,
            Country = dto.Country,
            City = dto.City,
            District = dto.District,
            Street = dto.Street,
            HouseNumber = dto.HouseNumber,
            ZipCode = dto.ZipCode
        };
    }

}

