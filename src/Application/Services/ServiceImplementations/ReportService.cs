using Application.Dtos;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Mappers;
using Domain.Entities;

namespace Application.Services;

public class ReportService : IReportService
{
    private readonly IReportRepository _reportRepository;

    public ReportService(IReportRepository reportRepository)
    {
        _reportRepository = reportRepository;
    }

    public async Task<ReportDto> CreateAsync(ReportCreateDto dto)
    {
        var report = ReportMapper.ToReportEntity(dto);
        await _reportRepository.AddReportAsync(report);
        return ReportMapper.ToReportDto(report);
    }

    public async Task<ReportDto?> GetByIdAsync(long id)
    {
        var report = await _reportRepository.GetByIdAsync(id);
        return report == null ? null : ReportMapper.ToReportDto(report);
    }

    public async Task<ICollection<ReportDto>> GetAllAsync()
    {
        var reports = await _reportRepository.GetAllAsync();
        return reports.Select(ReportMapper.ToReportDto).ToList();
    }

    public async Task<ICollection<ReportDto>> GetByUserIdAsync(long reporterId)
    {
        var reports = await _reportRepository.GetByUserIdAsync(reporterId);
        return reports.Select(ReportMapper.ToReportDto).ToList();
    }

    public async Task<ICollection<ReportDto>> GetByHomeIdAsync(long homeId)
    {
        var reports = await _reportRepository.GetByHomeIdAsync(homeId);
        return reports.Select(ReportMapper.ToReportDto).ToList();
    }

    public async Task DeleteAsync(long id)
    {
        await _reportRepository.DeleteReportAsync(id);
    }
}
