using Domain.Entities;

namespace Application.Interfaces;

public interface IHomeRepository
{
    Task<long> AddHomeAsync(Home home);
    Task DeleteHomeAsyc(long id);
    Task UpdateHomeAsync(Home home);
    Task<Home> GetHomeByIdAsync(long id);
    Task<ICollection<Home>> GetPagedHomesAsync(int pageNumber, int pageSize, string? sortBy = null, bool ascending = true);
    Task<ICollection<Home>> GetHomesByLocationAsync();
    Task<ICollection<Home>> GetHomesBetweenAsync(decimal minPrice, decimal maxPrice);
    Task<ICollection<Home>> GetHomesByCountOfRoomsAsync(int minCount, int maxCount);
    Task ReportHomeAsync(long homeId, string reason);

}