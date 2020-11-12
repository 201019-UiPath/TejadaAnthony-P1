using StoreAppDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreAppLib
{
    public interface ICartItemActions
    {
        void AddCartItem(CartItem cartItem);
        void UpdateCartItem(CartItem cartItem);
        CartItem GetCartItemById(int id);
        CartItem GetCartItemByCartId(int id);
        List<CartItem> GetAllCartItemsByCartId(int id);
        void DeleteCartItem(CartItem cartItem);
    }
}
