using Application.Dtos;

namespace Application.Interfaces.Services;

public interface IHomeService
{
    Task<long> CreateHomeAsync(HomeCreateDto dto);
    Task UpdateHomeAsync(HomeUpdateDto dto);
    Task DeleteHomeAsync(long id);
    Task<HomeDto?> GetHomeByIdAsync(long id);
    Task<ICollection<HomeDto>> GetPagedHomesAsync(int pageNumber, int pageSize, string? sortBy = null, bool ascending = true);
    Task<ICollection<HomeDto>> GetHomesByLocationAsync();
    Task<ICollection<HomeDto>> GetHomesBetweenAsync(decimal minPrice, decimal maxPrice);
    Task<ICollection<HomeDto>> GetHomesByCountOfRoomsAsync(int minCount, int maxCount);
    Task ReportHomeAsync(long homeId, string reason);
}
