using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ImageRepository (AppDbContext _context): IImageRepository
{
    

    public async Task<long> AddImageAsync(Image image)
    {
        await _context.Images.AddAsync(image);
        await _context.SaveChangesAsync();
        return image.Id;
    }

    public async Task AddImagesAsync(IEnumerable<Image> images)
    {
        await _context.Images.AddRangeAsync(images);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateImageAsync(Image image)
    {
        _context.Images.Update(image);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteImageAsync(long id)
    {
        var image = await _context.Images.FindAsync(id);
        if (image is not null)
        {
            _context.Images.Remove(image);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteImagesByHomeIdAsync(long homeId)
    {
        var images = await _context.Images
            .Where(i => i.HomeId == homeId)
            .ToListAsync();

        if (images.Any())
        {
            _context.Images.RemoveRange(images);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<Image?> GetImageByIdAsync(long id)
    {
        return await _context.Images
            .Include(i => i.Home)
            .FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<ICollection<Image>> GetImagesByHomeIdAsync(long homeId)
    {
        return await _context.Images
            .Where(i => i.HomeId == homeId)
            .OrderBy(i => i.Id)
            .ToListAsync();
    }

    public async Task<ICollection<string>> GetImageUrlsByHomeIdAsync(long homeId)
    {
        return await _context.Images
            .Where(i => i.HomeId == homeId)
            .Select(i => i.ImageUrl)
            .ToListAsync();
    }
}
