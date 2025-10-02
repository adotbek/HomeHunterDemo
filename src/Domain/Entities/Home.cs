using System.Text.Json.Nodes;

namespace Domain.Entities;

public class Home
{
    public long Id { get; set; }
    public string Bio { get; set; }
    public string Type { get; set; }
    public decimal Price { get; set; }
    public string OwnerNumber { get; set; }
    public long CategoryId { get; set; }
    public Category Category { get; set; }
    public int NumberOfRooms { get; set; }
    public ICollection<Image> Images { get; set; }
    public bool IsAvailable { get; set; } = false;
    public string Status { get; set; }

    public long LocationId { get; set; }
    public Location Location { get; set; }
}
