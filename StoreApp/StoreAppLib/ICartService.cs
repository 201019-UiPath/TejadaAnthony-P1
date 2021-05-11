using StoreAppDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreAppLib
{
   public  interface ICartService
    {
        void AddCart(Cart cart);
        void UpdateCart(Cart cart);
        Cart GetCartById(int id);
        Cart GetCartByUserId(int id);
        void DeleteCart(Cart cart);
    }
}
