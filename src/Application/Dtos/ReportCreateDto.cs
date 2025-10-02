namespace Application.Dtos;

public class ReportCreateDto
{
    public long ReporterId { get; set; }
    public long ReportedHomeId { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
