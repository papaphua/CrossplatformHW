using Blazorise;
using CrossplatformHW.Client.Auth.PermissionHandler;
using CrossplatformHW.Client.Services.CategoryService;
using CrossplatformHW.Client.Services.HttpInterceptorService;
using CrossplatformHW.Client.Services.ProductService;
using CrossplatformHW.Shared.Dtos;
using Microsoft.AspNetCore.Components;

namespace CrossplatformHW.Client.Pages.Management;

[HasPermission(Permissions.AdminPermission)]
public sealed partial class NewProduct : IDisposable
{
    private Validations _validations = new();
    [Inject] private IProductService ProductService { get; set; } = null!;
    [Inject] private ICategoryService CategoryService { get; set; } = null!;
    [Inject] private HttpInterceptorService HttpInterceptorService { get; set; } = null!;

    private ProductDto Product { get; } = new();
    private List<CategoryDto> Categories { get; set; } = new();

    public void Dispose()
    {
        HttpInterceptorService.DisposeEvent();
    }

    protected override async Task OnInitializedAsync()
    {
        HttpInterceptorService.RegisterEvent();
        Categories = await CategoryService.GetCategories();
    }

    private async Task AddAction()
    {
        if (await _validations.ValidateAll()) await ProductService.CreateProduct(Product);
    }
}