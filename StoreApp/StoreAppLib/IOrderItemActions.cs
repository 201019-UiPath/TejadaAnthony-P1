using StoreAppDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreAppLib
{
    interface IOrderItemActions
    {
        void AddOrderItem(OrderItem OrderItem);
        void UpdateOrderItem(OrderItem OrderItem);
        OrderItem GetOrderItemByOrderId(int id);
        List<OrderItem> GetAllOrderItemsByOrderId(int id);
        void DeleteOrderItem(OrderItem OrderItem);
    }
}
