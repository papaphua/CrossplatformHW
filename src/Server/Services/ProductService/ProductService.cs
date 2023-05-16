using CrossplatformHW.Server.Common.Extensions;
using CrossplatformHW.Server.Data;
using CrossplatformHW.Server.Data.Entities;
using CrossplatformHW.Shared.Pagination.Parameters;
using Microsoft.EntityFrameworkCore;

namespace CrossplatformHW.Server.Services.ProductService;

public sealed class ProductService : IProductService
{
    private readonly AppDbContext _db;

    public ProductService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<Product>> GetProductsByParametersAsync(ProductParameters parameters)
    {
        return await _db.Products
            .Include(product => product.Category)
            .WithCategory(parameters.Category)
            .SearchFor(parameters.Search)
            .OrderBy(product => product.Name)
            .ToListAsync();
    }

    public async Task<Product?> GetProductByIdAsync(Guid id)
    {
        return await _db.Products
            .FirstOrDefaultAsync(product => product.Id.Equals(id));
    }

    public async Task<Product?> GetProductBySlugAsync(string slug)
    {
        return await _db.Products
            .FirstOrDefaultAsync(product => product.Slug.Equals(slug));
    }
}