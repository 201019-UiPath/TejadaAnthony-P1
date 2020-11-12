using StoreAppDB.Interfaces;
using StoreAppDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreAppLib
{
    class CartActions : ICartActions
    {
        private ICartRepoActions repoActions;

        public void AddCart(Cart cart)
        {
            repoActions.AddCart(cart);
        }

        public void DeleteCart(Cart cart)
        {
            repoActions.DeleteCart(cart);
        }

        public Cart GetCartById(int id)
        {
            return repoActions.GetCartById(id);
        }

        public Cart GetCartByCustomerId(int id)
        {
            return repoActions.GetCartByCustomerId(id);
        }

        public void UpdateCart(Cart cart)
        {
            repoActions.UpdateCart(cart);
        }
    }
}
