using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class HomeRepository(AppDbContext _context) : IHomeRepository
{
    public async Task<long> AddHomeAsync(Home home)
    {
        await _context.Homes.AddAsync(home);
        await _context.SaveChangesAsync();
        return home.Id;
    }

    public async Task DeleteHomeAsyc(long id)
    {
        var home = await _context.Homes.FindAsync(id);
        if (home is not null)
        {
            _context.Homes.Remove(home);
            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateHomeAsync(Home home)
    {
        _context.Homes.Update(home);
        await _context.SaveChangesAsync();
    }

    public async Task<Home> GetHomeByIdAsync(long id)
    {
        return await _context.Homes
            .Include(h => h.Category)
            .Include(h => h.Location)
            .Include(h => h.Images)
            .FirstOrDefaultAsync(h => h.Id == id);
    }

    public async Task<ICollection<Home>> GetPagedHomesAsync(
        int pageNumber,
        int pageSize,
        string? sortBy = null,
        bool ascending = true)
    {
        IQueryable<Home> query = _context.Homes
            .Include(h => h.Category)
            .Include(h => h.Location);

        if (!string.IsNullOrEmpty(sortBy))
        {
            query = sortBy.ToLower() switch
            {
                "price" => ascending ? query.OrderBy(h => h.Price) : query.OrderByDescending(h => h.Price),
                "rooms" => ascending ? query.OrderBy(h => h.NumberOfRooms) : query.OrderByDescending(h => h.NumberOfRooms),
                _ => query.OrderBy(h => h.Id)
            };
        }

        return await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<ICollection<Home>> GetHomesByLocationAsync()
    {
        return await _context.Homes
            .Include(h => h.Location)
            .OrderBy(h => h.Location.City)
            .ToListAsync();
    }

    public async Task<ICollection<Home>> GetHomesBetweenAsync(decimal minPrice, decimal maxPrice)
    {
        return await _context.Homes
            .Where(h => h.Price >= minPrice && h.Price <= maxPrice)
            .OrderBy(h => h.Price)
            .ToListAsync();
    }


    public async Task<ICollection<Home>> GetHomesByCountOfRoomsAsync(int minCount, int maxCount)
    {
        return await _context.Homes
            .Where(h => h.NumberOfRooms >= minCount && h.NumberOfRooms <= maxCount)
            .OrderBy(h => h.NumberOfRooms)
            .ToListAsync();
    }

    public async Task ReportHomeAsync(long homeId, string reason)
    {
        var report = new Report
        {
            ReportedHomeId = homeId,
            Description = reason,
            CreatedAt = DateTime.UtcNow
        };

        await _context.Reports.AddAsync(report);
        await _context.SaveChangesAsync();
    }
}
