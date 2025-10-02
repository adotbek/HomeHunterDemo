namespace Application.Dtos;

public class ReportDto
{
    public long Id { get; set; }
    public long ReporterId { get; set; }
    public long ReportedHomeId { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
