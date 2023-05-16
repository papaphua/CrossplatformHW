using CrossplatformHW.Server.Primitives;
using CrossplatformHW.Shared.Dtos;
using CrossplatformHW.Shared.Pagination.Parameters;

namespace CrossplatformHW.Server.Facades.ProductFacade;

public interface IProductFacade
{
    Task<PagedList<ProductDto>> GetProductsByParametersAsync(ProductParameters parameters);
    Task<ProductDto?> GetProductBySlugAsync(string slug);
    Task CreateProductAsync(ProductDto dto);
    Task UpdateProductAsync(ProductDto dto);
    Task DeleteProductAsync(string slug);
}