using Application.Dtos;

namespace Application.Interfaces.Services;

public interface ILocationService
{
    Task<long> CreateLocationAsync(LocationCreateDto dto);
    Task UpdateLocationAsync(LocationUpdateDto dto);
    Task DeleteLocationAsync(long id);
    Task<LocationDto?> GetByIdAsync(long id);
    Task<ICollection<LocationDto>> GetAllAsync();
    Task<ICollection<LocationDto>> GetByCityAsync(string city);
    Task<ICollection<LocationDto>> GetByCountryAsync(string country);
    Task<ICollection<LocationDto>> GetByZipCodeAsync(string zipCode);
}
