using StoreAppDB.Interfaces;
using StoreAppDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreAppLib
{
    public class CartService : ICartService
    {
        private ICartRepoActions repo;
        public CartService(ICartRepoActions repo)
        {
            this.repo = repo;
        }

        public void AddCart(Cart cart)
        {
            repo.AddCart(cart);
        }

        public void DeleteCart(Cart cart)
        {
            repo.DeleteCart(cart);
        }

        public Cart GetCartById(int id)
        {
            return repo.GetCartById(id);
        }

        public Cart GetCartByUserId(int id)
        {
            return repo.GetCartByUserId(id);
        }

        public void UpdateCart(Cart cart)
        {
            repo.UpdateCart(cart);
        }
    }
}
