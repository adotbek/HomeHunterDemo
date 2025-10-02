using Application.Dtos;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Mappers;
using Domain.Entities;

namespace Application.Services;

public class HomeService : IHomeService
{
    private readonly IHomeRepository _homeRepository;

    public HomeService(IHomeRepository homeRepository)
    {
        _homeRepository = homeRepository;
    }

    public async Task<long> CreateHomeAsync(HomeCreateDto dto)
    {
        var entity = HomeMapper.ToHomeEntity(dto);

        
        entity.Images = dto.ImageUrls
            .Select(url => new Image { ImageUrl = url, Home = entity })
            .ToList();

        return await _homeRepository.AddHomeAsync(entity);
    }

    public async Task UpdateHomeAsync(HomeUpdateDto dto)
    {
        var entity = HomeMapper.ToHomeEntity(dto);
        await _homeRepository.UpdateHomeAsync(entity);
    }

    public async Task DeleteHomeAsync(long id)
    {
        await _homeRepository.DeleteHomeAsyc(id);
    }

    public async Task<HomeDto?> GetHomeByIdAsync(long id)
    {
        var entity = await _homeRepository.GetHomeByIdAsync(id);
        return entity is null ? null : HomeMapper.ToHomeDto(entity);
    }

    public async Task<ICollection<HomeDto>> GetPagedHomesAsync(int pageNumber, int pageSize, string? sortBy = null, bool ascending = true)
    {
        var homes = await _homeRepository.GetPagedHomesAsync(pageNumber, pageSize, sortBy, ascending);
        return homes.Select(HomeMapper.ToHomeDto).ToList();
    }

    public async Task<ICollection<HomeDto>> GetHomesByLocationAsync()
    {
        var homes = await _homeRepository.GetHomesByLocationAsync();
        return homes.Select(HomeMapper.ToHomeDto).ToList();
    }

    public async Task<ICollection<HomeDto>> GetHomesBetweenAsync(decimal minPrice, decimal maxPrice)
    {
        var homes = await _homeRepository.GetHomesBetweenAsync(minPrice, maxPrice);
        return homes.Select(HomeMapper.ToHomeDto).ToList();
    }

    public async Task<ICollection<HomeDto>> GetHomesByCountOfRoomsAsync(int minCount, int maxCount)
    {
        var homes = await _homeRepository.GetHomesByCountOfRoomsAsync(minCount, maxCount);
        return homes.Select(HomeMapper.ToHomeDto).ToList();
    }

    public async Task ReportHomeAsync(long homeId, string reason)
    {
        await _homeRepository.ReportHomeAsync(homeId, reason);
    }
}
