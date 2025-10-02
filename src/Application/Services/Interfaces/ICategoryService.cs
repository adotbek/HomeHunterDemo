using Application.Dtos;

namespace Application.Interfaces;

public interface ICategoryService
{
    Task<long> AddCategoryAsync(string name);
    Task UpdateCategoryAsync(CategoryDto dto);
    Task DeleteCategoryAsync(long id);
    Task<CategoryDto?> GetByIdAsync(long id);
    Task<CategoryDto?> GetByNameAsync(string name);
    Task<ICollection<CategoryDto>> GetAllAsync();
}
