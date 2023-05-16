using CrossplatformHW.Server.Data.Entities;

namespace CrossplatformHW.Server.Common.Extensions;

public static class ProductExtensions
{
    public static IQueryable<Product> SearchFor(this IQueryable<Product> products, string? search)
    {
        if (string.IsNullOrWhiteSpace(search)) return products;

        var formattedSearch = search.Trim().ToLower();

        return products
            .Where(product => product.Name.ToLower().Contains(formattedSearch));
    }

    public static IQueryable<Product> WithCategory(this IQueryable<Product> products, string? categorySlug)
    {
        if (string.IsNullOrWhiteSpace(categorySlug)) return products;

        return products
            .Where(product => product.Category.Slug.Contains(categorySlug));
    }
}