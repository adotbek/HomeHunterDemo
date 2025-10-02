using Application.Dtos;

namespace Application.Interfaces.Services;

public interface IReportService
{
    Task<ReportDto> CreateAsync(ReportCreateDto dto);
    Task<ReportDto?> GetByIdAsync(long id);
    Task<ICollection<ReportDto>> GetAllAsync();
    Task<ICollection<ReportDto>> GetByUserIdAsync(long reporterId);
    Task<ICollection<ReportDto>> GetByHomeIdAsync(long homeId);
    Task DeleteAsync(long id);
}
