using CrossplatformHW.Client.Models.Pagination;
using CrossplatformHW.Shared.Dtos;
using CrossplatformHW.Shared.Pagination.Parameters;

namespace CrossplatformHW.Client.Services.ProductService;

public interface IProductService
{
    Task<PagingResponse<ProductDto>> GetProducts(ProductParameters parameters);
    Task<ProductDto> GetProductByUri(string uri);
    Task UpdateProduct(ProductDto dto);
    Task CreateProduct(ProductDto dto);
    Task DeleteProduct(string uri);
}