using Application.Dtos;
using Application.Interfaces;
using Application.Interfaces.Services;
using Application.Mappers;
using Domain.Entities;

namespace Application.Services;

public class ImageService : IImageService
{
    private readonly IImageRepository _imageRepository;

    public ImageService(IImageRepository imageRepository)
    {
        _imageRepository = imageRepository;
    }

    public async Task<long> CreateImageAsync(ImageCreateDto dto)
    {
        var entity = ImageMapper.ToImageEntity(dto);
        return await _imageRepository.AddImageAsync(entity);
    }

    public async Task CreateImagesAsync(IEnumerable<ImageCreateDto> dtos)
    {
        var entities = dtos.Select(ImageMapper.ToImageEntity).ToList();
        await _imageRepository.AddImagesAsync(entities);
    }

    public async Task UpdateImageAsync(ImageUpdateDto dto)
    {
        var entity = new Image
        {
            Id = dto.Id,
            ImageUrl = dto.ImageUrl,
            HomeId = dto.HomeId
        };

        await _imageRepository.UpdateImageAsync(entity);
    }

    public async Task DeleteImageAsync(long id)
    {
        await _imageRepository.DeleteImageAsync(id);
    }

    public async Task DeleteImagesByHomeIdAsync(long homeId)
    {
        await _imageRepository.DeleteImagesByHomeIdAsync(homeId);
    }

    public async Task<ImageDto?> GetImageByIdAsync(long id)
    {
        var entity = await _imageRepository.GetImageByIdAsync(id);
        return entity is null ? null : ImageMapper.ToImageDto(entity);
    }

    public async Task<ICollection<ImageDto>> GetImagesByHomeIdAsync(long homeId)
    {
        var entities = await _imageRepository.GetImagesByHomeIdAsync(homeId);
        return entities.Select(ImageMapper.ToImageDto).ToList();
    }

    public async Task<ICollection<string>> GetImageUrlsByHomeIdAsync(long homeId)
    {
        return await _imageRepository.GetImageUrlsByHomeIdAsync(homeId);
    }
}
