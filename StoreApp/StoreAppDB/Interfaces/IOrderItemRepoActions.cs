using StoreAppDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreAppDB.Interfaces
{
    public interface IOrderItemRepoActions
    {
        void AddOrderItem(OrderItem orderItem);
        void UpdateOrderItem(OrderItem orderItem);
        OrderItem GetOrderItemByOrderId(int id);
        List<OrderItem> GetAllOrderItemsByOrderId(int id);
        void DeleteOrderItem(OrderItem orderItem);
    }
}
