using CrossplatformHW.Shared.Dtos;

namespace CrossplatformHW.Client.Services.CategoryService;

public interface ICategoryService
{
    Task<List<CategoryDto>> GetCategories();
}