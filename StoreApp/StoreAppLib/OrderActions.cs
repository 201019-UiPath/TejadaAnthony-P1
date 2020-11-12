using StoreAppDB.Models;
using StoreAppDB.Interfaces;
using StoreAppDB;
using System.Collections.Generic;

namespace StoreAppLib
{
    public class OrderActions
    {
        
        private StoreAppContext context;
        private IOrderRepoActions orderRepo;

        public OrderActions(StoreAppContext context, IOrderRepoActions orderRepo)
        {
            this.context = context;
            this.orderRepo = orderRepo;
        }

        public void AddNewOrder(Order order) {

            orderRepo.AddOrderToTable(order);

        }

        public List<Order> GetOrdersByLocationId(int locationId)
        {
           return orderRepo.GetOrdersByLocationId(locationId);
        }

        public List<Order> GetOrdersByCustomerId(int cusId)
        {
            return orderRepo.GetOrdersByCustomerId(cusId);
        }

    }
}