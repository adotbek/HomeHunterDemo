using Domain.Entities;

namespace Application.Dtos;

public class HomeCreateDto
{
    public string Bio { get; set; }
    public string Type { get; set; }
    public decimal Price { get; set; }
    public string OwnerNumber { get; set; }
    public int NumberOfRooms { get; set; }
    public ICollection<string> ImageUrls { get; set; }
    public bool IsAvailable { get; set; } = false;
    public long LocationId { get; set; }
    public long CategoryId { get; set; }

}
