using StoreAppDB.Interfaces;
using StoreAppDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreAppLib
{
    public class CartItemActions : ICartItemActions
    {
        private ICartItemRepoActions repoActions;

        public CartItemActions(ICartItemRepoActions repoActions)
        {
            this.repoActions = repoActions;
        }

        public void AddCartItem(CartItem cartItem)
        {
            repoActions.AddCartItem(cartItem);
        }

        public void DeleteCartItem(CartItem cartItem)
        {
            repoActions.DeleteCartItem(cartItem);
        }

        public List<CartItem> GetAllCartItemsByCartId(int id)
        {
            return repoActions.GetAllCartItemsByCartId(id);
        }

        public CartItem GetCartItemByCartId(int id)
        {
            return repoActions.GetCartItemByCartId(id);
        }

        public CartItem GetCartItemById(int id)
        {
            return repoActions.GetCartItemById(id);
        }

        public void UpdateCartItem(CartItem cartItem)
        {
            repoActions.UpdateCartItem(cartItem);
        }
    }
}
