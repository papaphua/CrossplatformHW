using CrossplatformHW.Client.Services.HttpInterceptorService;
using CrossplatformHW.Client.Services.ProductService;
using CrossplatformHW.Shared.Dtos;
using CrossplatformHW.Shared.Pagination;
using CrossplatformHW.Shared.Pagination.Parameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace CrossplatformHW.Client.Pages.Products;

[AllowAnonymous]
public sealed partial class Products : IDisposable
{
    private readonly ProductParameters _productParameters = new() { PageSize = 15 };
    [Inject] private IProductService ProductService { get; set; } = null!;
    [Inject] private HttpInterceptorService HttpInterceptorService { get; set; } = null!;

    [Parameter] public string? CategoryUrl { get; set; }
    private List<ProductDto> Items { get; set; } = new();
    private MetaData MetaData { get; set; } = new();

    public void Dispose()
    {
        HttpInterceptorService.DisposeEvent();
    }

    protected override void OnInitialized()
    {
        HttpInterceptorService.RegisterEvent();
    }

    protected override async Task OnParametersSetAsync()
    {
        _productParameters.PageNumber = 1;
        _productParameters.Category = CategoryUrl;
        _productParameters.Search = string.Empty;
        await GetProducts();
    }

    private async Task GetProducts()
    {
        var pagingResponse = await ProductService.GetProducts(_productParameters);

        Items = pagingResponse.Items;
        MetaData = pagingResponse.MetaData;
    }

    private async Task SelectPageAction(int page)
    {
        _productParameters.PageNumber = page;
        await GetProducts();
    }
}