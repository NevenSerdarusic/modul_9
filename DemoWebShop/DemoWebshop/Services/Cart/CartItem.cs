﻿using DemoWebshop.Models;

namespace DemoWebshop.Services.Cart;

public class CartItem
{
    public Product Product { get; set; }

    public decimal Quantity { get; set; }

    public decimal GetTotal()
    {
        return Product.Price * Quantity;
    }
}
