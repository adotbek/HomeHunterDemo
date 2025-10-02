using Application.Dtos;
using Domain.Entities;

namespace Application.Mappers;

public class ReportMapper
{
    public static Report ToReportEntity(ReportCreateDto dto)
    {
        return new Report
        {
            ReportedHomeId = dto.ReportedHomeId,
            ReporterId = dto.ReporterId,
            Description = dto.Description,
            CreatedAt = dto.CreatedAt
        };
    }
    public static ReportDto ToReportDto(Report report)
    {
        return new ReportDto
        {
            Id = report.Id,
            ReporterId = report.ReporterId,
            ReportedHomeId = report.ReportedHomeId,
            Description = report.Description,
            CreatedAt = report.CreatedAt
        };
    }
}
