using CrossplatformHW.Client.Services.CategoryService;
using CrossplatformHW.Client.Services.ProfileService;
using CrossplatformHW.Shared.Dtos;
using Microsoft.AspNetCore.Components;

namespace CrossplatformHW.Client.Shared;

public sealed partial class SideMenu
{
    [Inject] private ICategoryService CategoryService { get; set; } = null!;
    [Inject] private IProfileService ProfileService { get; set; } = null!;

    private List<CategoryDto> Categories { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        Categories = await CategoryService.GetCategories();
    }
}