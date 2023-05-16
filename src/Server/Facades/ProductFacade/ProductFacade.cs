using AutoMapper;
using CrossplatformHW.Server.Common;
using CrossplatformHW.Server.Common.Exceptions;
using CrossplatformHW.Server.Data;
using CrossplatformHW.Server.Data.Entities;
using CrossplatformHW.Server.Primitives;
using CrossplatformHW.Server.Services.ProductService;
using CrossplatformHW.Shared.Dtos;
using CrossplatformHW.Shared.Pagination.Parameters;

namespace CrossplatformHW.Server.Facades.ProductFacade;

public sealed class ProductFacade : IProductFacade
{
    private readonly AppDbContext _db;
    private readonly IMapper _mapper;
    private readonly IProductService _productService;

    public ProductFacade(IMapper mapper, IProductService productService, AppDbContext db)
    {
        _mapper = mapper;
        _productService = productService;
        _db = db;
    }

    public async Task<PagedList<ProductDto>> GetProductsByParametersAsync(ProductParameters parameters)
    {
        var products = await _productService.GetProductsByParametersAsync(parameters);

        var dtos = products
            .Select(product => _mapper.Map<ProductDto>(product))
            .ToList();

        return PagedList<ProductDto>
            .ToPagedList(dtos, parameters.PageNumber, parameters.PageSize);
    }

    public async Task<ProductDto?> GetProductBySlugAsync(string uri)
    {
        var product = await _productService.GetProductBySlugAsync(uri);

        return _mapper.Map<ProductDto>(product);
    }

    public async Task CreateProductAsync(ProductDto dto)
    {
        var product = _mapper.Map<Product>(dto);

        await _db.Products.AddAsync(product);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateProductAsync(ProductDto dto)
    {
        var product = await _productService.GetProductBySlugAsync(dto.Slug);

        if (product is null) throw new NotFoundException(ExceptionMessages.ProductNotFound);

        _mapper.Map(dto, product);

        await _db.SaveChangesAsync();
    }

    public async Task DeleteProductAsync(string slug)
    {
        var product = await _productService.GetProductBySlugAsync(slug);

        if (product is null) throw new NotFoundException(ExceptionMessages.ProductNotFound);

        _db.Products.Remove(product);
        await _db.SaveChangesAsync();
    }
}