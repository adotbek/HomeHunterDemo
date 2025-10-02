using Application.Dtos;

namespace Application.Interfaces.Services;

public interface IImageService
{
    Task<long> CreateImageAsync(ImageCreateDto dto);
    Task CreateImagesAsync(IEnumerable<ImageCreateDto> dtos);
    Task UpdateImageAsync(ImageUpdateDto dto);
    Task DeleteImageAsync(long id);
    Task DeleteImagesByHomeIdAsync(long homeId);
    Task<ImageDto?> GetImageByIdAsync(long id);
    Task<ICollection<ImageDto>> GetImagesByHomeIdAsync(long homeId);
    Task<ICollection<string>> GetImageUrlsByHomeIdAsync(long homeId);
}
