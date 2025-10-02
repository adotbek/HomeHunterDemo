using Domain.Entities;

namespace Application.Interfaces;

public interface ICategoryRepository
{
    Task<long> AddCategoryAsync(Category category);
    Task UpdateCategoryAsync(Category category);
    Task DeleteCategoryAsync(long id);
    Task<Category> GetByIdAsync(long id);
    Task<Category> GetByNameAsync(string name);
    Task<ICollection<Category>> GetAllAsync();
}
