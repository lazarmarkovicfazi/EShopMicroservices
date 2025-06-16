﻿using Marten.Schema;

namespace BasketAPI.Models
{
    public class ShoppingCart
    {
        [Identity]
        public string UserName { get; set; } = default!;
        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();
        public decimal TotalPrice => Items.Sum(item => item.Price * item.Quantity);

        public ShoppingCart(string userName)
        {
            UserName = userName;
        }

        //required for Mapping
        public ShoppingCart()
        {
        }
    }
}
