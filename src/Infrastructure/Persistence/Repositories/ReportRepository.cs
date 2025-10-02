using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ReportRepository(AppDbContext _context) : IReportRepository
{
    public async Task AddReportAsync(Report report)
    {
        await _context.Reports.AddAsync(report);
        await _context.SaveChangesAsync();
    }

    public async Task<Report?> GetByIdAsync(long id)
    {
        return await _context.Reports
            .Include(r => r.Reporter)
            .Include(r => r.ReportedHome)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<ICollection<Report>> GetAllAsync()
    {
        return await _context.Reports
            .Include(r => r.Reporter)
            .Include(r => r.ReportedHome)
            .OrderByDescending(r => r.CreatedAt)
            .ToListAsync();
    }

    public async Task<ICollection<Report>> GetByUserIdAsync(long reporterId)
    {
        return await _context.Reports
            .Include(r => r.ReportedHome)
            .Where(r => r.ReporterId == reporterId)
            .OrderByDescending(r => r.CreatedAt)
            .ToListAsync();
    }

    public async Task<ICollection<Report>> GetByHomeIdAsync(long homeId)
    {
        return await _context.Reports
            .Include(r => r.Reporter)
            .Where(r => r.ReportedHomeId == homeId)
            .OrderByDescending(r => r.CreatedAt)
            .ToListAsync();
    }

    public async Task DeleteReportAsync(long id)
    {
        var report = await _context.Reports.FindAsync(id);
        if (report != null)
        {
            _context.Reports.Remove(report);
            await _context.SaveChangesAsync();
        }
    }
}
