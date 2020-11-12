using StoreAppDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreAppDB.Interfaces
{
   public interface ICartRepoActions
    {
        void AddCart(Cart cart);
        void UpdateCart(Cart cart);
        Cart GetCartById(int id );
        Cart GetCartByCustomerId(int id);
        void DeleteCart(Cart cart);

    }
}
