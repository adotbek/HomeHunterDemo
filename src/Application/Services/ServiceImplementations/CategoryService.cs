using Application.Dtos;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Mappers;
using Domain.Entities;

namespace Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;

    public CategoryService(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<long> AddCategoryAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Category name cannot be empty.");

        var existing = await _repository.GetByNameAsync(name);
        if (existing != null)
            throw new InvalidOperationException($"Category '{name}' already exists.");

        var category = new Category { Name = name };
        return await _repository.AddCategoryAsync(category);
    }

    public async Task UpdateCategoryAsync(CategoryDto dto)
    {
        if (dto.Id <= 0)
            throw new ArgumentException("Invalid category ID.");
        if (string.IsNullOrWhiteSpace(dto.Name))
            throw new ArgumentException("Category name cannot be empty.");

        var entity = CategoryMapper.ToCategoryEntity(dto);
        await _repository.UpdateCategoryAsync(entity);
    }

    public async Task DeleteCategoryAsync(long id)
    {
        if (id <= 0)
            throw new ArgumentException("Invalid category ID.");

        await _repository.DeleteCategoryAsync(id);
    }

    public async Task<CategoryDto?> GetByIdAsync(long id)
    {
        var category = await _repository.GetByIdAsync(id);
        return category == null ? null : CategoryMapper.ToCategoryDto(category);
    }

    public async Task<CategoryDto?> GetByNameAsync(string name)
    {
        var category = await _repository.GetByNameAsync(name);
        return category == null ? null : CategoryMapper.ToCategoryDto(category);
    }

    public async Task<ICollection<CategoryDto>> GetAllAsync()
    {
        var categories = await _repository.GetAllAsync();
        return categories.Select(CategoryMapper.ToCategoryDto).ToList();
    }
}
