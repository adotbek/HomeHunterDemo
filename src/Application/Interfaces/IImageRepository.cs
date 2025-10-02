using Domain.Entities;

namespace Application.Interfaces;

public interface IImageRepository
{
    Task<long> AddImageAsync(Image image);
    Task AddImagesAsync(IEnumerable<Image> images);

    Task UpdateImageAsync(Image image);
    Task DeleteImageAsync(long id);
    Task DeleteImagesByHomeIdAsync(long homeId);

    Task<Image?> GetImageByIdAsync(long id);
    Task<ICollection<Image>> GetImagesByHomeIdAsync(long homeId);

    Task<ICollection<string>> GetImageUrlsByHomeIdAsync(long homeId);
}
