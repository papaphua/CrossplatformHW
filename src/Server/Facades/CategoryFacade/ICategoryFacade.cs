using CrossplatformHW.Shared.Dtos;

namespace CrossplatformHW.Server.Facades.CategoryFacade;

public interface ICategoryFacade
{
    Task<List<CategoryDto>> GetAllCategoriesAsync();
}