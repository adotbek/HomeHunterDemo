using Domain.Entities;

namespace Application.Interfaces;

public interface ILocationRepository
{
    Task<long> AddLocationAsync(Location location);
    Task UpdateLocationAsync(Location location);
    Task DeleteLocationAsync(long id);
    Task<Location?> GetLocationByIdAsync(long id);
    Task<ICollection<Location>> GetAllLocationsAsync();
    Task<ICollection<Location>> GetLocationsByCityAsync(string city);
    Task<ICollection<Location>> GetLocationsByCountryAsync(string country);
    Task<ICollection<Location>> GetLocationsByZipCodeAsync(string zipCode);
}
