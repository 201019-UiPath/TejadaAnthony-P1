using StoreAppDB.Models;
using StoreAppDB.Interfaces;
using StoreAppDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreAppLib
{
   public  class OrderItemActions : IOrderItemActions
    {
       public IOrderItemRepoActions repoActions;

        public OrderItemActions(IOrderItemRepoActions repoActions)
        {
            this.repoActions = repoActions;
        }

        public void AddOrderItem(OrderItem OrderItem)
        {
            repoActions.AddOrderItem(OrderItem);
        }

        public void DeleteOrderItem(OrderItem OrderItem)
        {
            repoActions.DeleteOrderItem(OrderItem);
        }

        public List<OrderItem> GetAllOrderItemsByOrderId(int id)
        {
            return repoActions.GetAllOrderItemsByOrderId(id);
        }

        public OrderItem GetOrderItemByOrderId(int id)
        {
            return repoActions.GetOrderItemByOrderId(id);
        }

        public void UpdateOrderItem(OrderItem OrderItem)
        {
            repoActions.UpdateOrderItem(OrderItem);
        }
    }
}
