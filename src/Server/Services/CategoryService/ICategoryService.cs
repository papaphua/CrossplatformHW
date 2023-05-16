using CrossplatformHW.Server.Data.Entities;

namespace CrossplatformHW.Server.Services.CategoryService;

public interface ICategoryService
{
    Task<List<Category>> GetAllCategoriesAsync();
}