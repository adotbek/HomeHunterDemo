using Domain.Entities;

namespace Application.Dtos;

public class ImageCreateDto
{
    public string ImageUrl { get; set; }
    public long HomeId { get; set; }
}   
