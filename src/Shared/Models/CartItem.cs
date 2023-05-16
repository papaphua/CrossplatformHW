using System.ComponentModel.DataAnnotations;
using CrossplatformHW.Shared.Dtos;

namespace CrossplatformHW.Shared.Models;

public class CartItem
{
    public CartItem(ProductDto product)
    {
        Product = product;
    }

    [Required] public ProductDto Product { get; }

    [Required] public int Quantity { get; set; } = 1;
}