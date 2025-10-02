namespace Domain.Entities;

public class Report
{
    public long Id { get; set; }
    public long ReporterId { get; set; }
    public User Reporter { get; set; }
    public long ReportedHomeId { get; set; }
    public Home ReportedHome { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
