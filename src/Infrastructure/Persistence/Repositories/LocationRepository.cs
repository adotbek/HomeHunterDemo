using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

public class LocationRepository(AppDbContext _context) : ILocationRepository
{
    public async Task<long> AddLocationAsync(Location location)
    {
        _context.Locations.Add(location);
        await _context.SaveChangesAsync();
        return location.Id;
    }

    public async Task UpdateLocationAsync(Location location)
    {
        _context.Locations.Update(location);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteLocationAsync(long id)
    {
        var entity = await _context.Locations.FindAsync(id);
        if (entity != null)
        {
            _context.Locations.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<Location?> GetLocationByIdAsync(long id)
    {
        return await _context.Locations
            .Include(l => l.Homes)
            .FirstOrDefaultAsync(l => l.Id == id);
    }

    public async Task<ICollection<Location>> GetAllLocationsAsync()
    {
        return await _context.Locations
            .Include(l => l.Homes)
            .ToListAsync();
    }

    public async Task<ICollection<Location>> GetLocationsByCityAsync(string city)
    {
        return await _context.Locations
            .Where(l => l.City == city)
            .ToListAsync();
    }

    public async Task<ICollection<Location>> GetLocationsByCountryAsync(string country)
    {
        return await _context.Locations
            .Where(l => l.Country == country)
            .ToListAsync();
    }

    public async Task<ICollection<Location>> GetLocationsByZipCodeAsync(string zipCode)
    {
        return await _context.Locations
            .Where(l => l.ZipCode == zipCode)
            .ToListAsync();
    }
}
