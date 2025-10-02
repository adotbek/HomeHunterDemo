using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IReportRepository
{
    Task AddReportAsync(Report report);
    Task<Report?> GetByIdAsync(long id);
    Task<ICollection<Report>> GetAllAsync();
    Task<ICollection<Report>> GetByUserIdAsync(long reporterId);
    Task<ICollection<Report>> GetByHomeIdAsync(long homeId);
    Task DeleteReportAsync(long id);
}
