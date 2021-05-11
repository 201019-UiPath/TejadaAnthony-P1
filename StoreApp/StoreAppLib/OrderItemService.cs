using StoreAppDB.Models;
using StoreAppDB.Interfaces;
using StoreAppDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreAppLib
{
   public  class OrderItemService : IOrderItemService
    {
       public IOrderItemRepoActions repo;

        public OrderItemService(IOrderItemRepoActions repoActions)
        {
            this.repo = repoActions;
        }

        public void AddOrderItem(OrderItem OrderItem)
        {
            repo.AddOrderItem(OrderItem);
        }

        public void DeleteOrderItem(OrderItem OrderItem)
        {
            repo.DeleteOrderItem(OrderItem);
        }

        public List<OrderItem> GetAllOrderItemsByOrderId(int id)
        {
            return repo.GetAllOrderItemsByOrderId(id);
        }

        public OrderItem GetOrderItemByOrderId(int id)
        {
            return repo.GetOrderItemByOrderId(id);
        }

        public void UpdateOrderItem(OrderItem OrderItem)
        {
            repo.UpdateOrderItem(OrderItem);
        }
    }
}
