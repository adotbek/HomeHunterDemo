using Domain.Entities;

namespace Application.Dtos;

public class ImageUpdateDto
{
    public long Id { get; set; }
    public string ImageUrl { get; set; }
    public long HomeId { get; set; }
}
