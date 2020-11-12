using StoreAppDB.Models;
using System.Collections.Generic;

namespace StoreAppDB.Interfaces
{
    public interface IOrderRepoActions
    {
        void AddOrderToTable(Order order);

        List<Order> GetOrdersByLocationId(int locationId);
        List<Order> GetOrdersByCustomerId(int cusId);
    }
}