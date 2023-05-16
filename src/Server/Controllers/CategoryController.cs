using CrossplatformHW.Server.Facades.CategoryFacade;
using CrossplatformHW.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrossplatformHW.Server.Controllers;

[Route("api/categories")]
[ApiController]
public sealed class CategoryController : ControllerBase
{
    private readonly ICategoryFacade _categoryFacade;

    public CategoryController(ICategoryFacade categoryFacade)
    {
        _categoryFacade = categoryFacade;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<List<CategoryDto>> GetCategories()
    {
        return await _categoryFacade.GetAllCategoriesAsync();
    }
}