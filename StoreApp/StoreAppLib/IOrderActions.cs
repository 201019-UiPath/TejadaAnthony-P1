using StoreAppDB.Models;
using System.Collections.Generic;

namespace StoreAppLib
{
    public interface IOrderActions
    {
        List<Order> GetAllOrders();
        void AddNewOrder(Order order);
        List<Order> GetOrdersByCustomerId(int cusId);
        List<Order> GetOrdersByLocationId(int locationId);
        Order GetOrderByDate(string date);
    }
}