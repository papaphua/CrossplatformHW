using CrossplatformHW.Server.Data.Entities;
using CrossplatformHW.Shared.Pagination.Parameters;

namespace CrossplatformHW.Server.Services.ProductService;

public interface IProductService
{
    Task<List<Product>> GetProductsByParametersAsync(ProductParameters parameters);
    Task<Product?> GetProductByIdAsync(Guid id);
    Task<Product?> GetProductBySlugAsync(string slug);
}