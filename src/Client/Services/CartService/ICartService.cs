﻿using CrossplatformHW.Shared.Dtos;
using CrossplatformHW.Shared.Models;

namespace CrossplatformHW.Client.Services.CartService;

public interface ICartService
{
    Task<List<CartItem>> GetAllItems();
    decimal GetCartPrice(List<CartItem> cart);
    Task AddToCart(ProductDto product);
    Task RemoveFromCart(CartItem item, List<CartItem> cart);
    Task SaveCart(List<CartItem> cart);
    Task ClearCart(List<CartItem> cart);
}