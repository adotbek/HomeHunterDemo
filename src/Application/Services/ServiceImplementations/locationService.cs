using Application.Dtos;
using Application.Interfaces;
using Application.Interfaces.Services;
using Application.Mappers;
using Domain.Entities;

namespace Application.Services;

public class LocationService : ILocationService
{
    private readonly ILocationRepository _locationRepository;

    public LocationService(ILocationRepository locationRepository)
    {
        _locationRepository = locationRepository;
    }

    public async Task<long> CreateLocationAsync(LocationCreateDto dto)
    {
        var entity = LocationMapper.ToLocationEntity(dto);
        return await _locationRepository.AddLocationAsync(entity);
    }

    public async Task UpdateLocationAsync(LocationUpdateDto dto)
    {
        var entity = LocationMapper.ToLocationEntity(dto);
        await _locationRepository.UpdateLocationAsync(entity);
    }


    public async Task DeleteLocationAsync(long id)
    {
        await _locationRepository.DeleteLocationAsync(id);
    }

    public async Task<LocationDto?> GetByIdAsync(long id)
    {
        var entity = await _locationRepository.GetLocationByIdAsync(id);
        return entity is null ? null : LocationMapper.ToLocationDto(entity);
    }

    public async Task<ICollection<LocationDto>> GetAllAsync()
    {
        var entities = await _locationRepository.GetAllLocationsAsync();
        return entities.Select(LocationMapper.ToLocationDto).ToList();
    }

    public async Task<ICollection<LocationDto>> GetByCityAsync(string city)
    {
        var entities = await _locationRepository.GetLocationsByCityAsync(city);
        return entities.Select(LocationMapper.ToLocationDto).ToList();
    }

    public async Task<ICollection<LocationDto>> GetByCountryAsync(string country)
    {
        var entities = await _locationRepository.GetLocationsByCountryAsync(country);
        return entities.Select(LocationMapper.ToLocationDto).ToList();
    }

    public async Task<ICollection<LocationDto>> GetByZipCodeAsync(string zipCode)
    {
        var entities = await _locationRepository.GetLocationsByZipCodeAsync(zipCode);
        return entities.Select(LocationMapper.ToLocationDto).ToList();
    }
}
