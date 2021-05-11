using StoreAppDB.Models;
using StoreAppDB.Interfaces;
using StoreAppDB;
using System.Collections.Generic;
using System;

namespace StoreAppLib
{
    public class OrderService : IOrderService
    {

        private StoreAppContext context;
        private IOrderRepoActions repo;

        public OrderService(StoreAppContext context, IOrderRepoActions repo)
        {
            this.context = context;
            this.repo = repo;
        }

        public void AddOrder(Order order)
        {
            repo.AddOrder(order);
        }

        public void DeleteOrder(Order order)
        {
            repo.DeleteOrder(order);
        }

        public List<Order> GetAllOrdersByLocationId(int id)
        {
            return repo.GetAllOrdersByLocationId(id);
        }

        public List<Order> GetAllOrdersByLocationIdDateAsc(int id)
        {
            return repo.GetAllOrdersByLocationIdDateAsc(id);
        }

        public List<Order> GetAllOrdersByLocationIdDateDesc(int id)
        {
            return repo.GetAllOrdersByLocationIdDateDesc(id);
        }

        public List<Order> GetAllOrdersByLocationIdPriceAsc(int id)
        {
            return repo.GetAllOrdersByLocationIdPriceAsc(id);
        }

        public List<Order> GetAllOrdersByLocationIdPriceDesc(int id)
        {
            return repo.GetAllOrdersByLocationIdPriceDesc(id);
        }

        public List<Order> GetAllOrdersByUserId(int id)
        {
            return repo.GetAllOrdersByUserId(id);
        }

        public List<Order> GetAllOrdersByUserIdDateAsc(int id)
        {
            return repo.GetAllOrdersByUserIdDateAsc(id);
        }

        public List<Order> GetAllOrdersByUserIdDateDesc(int id)
        {
            return repo.GetAllOrdersByUserIdDateDesc(id);
        }

        public List<Order> GetAllOrdersByUserIdPriceAsc(int id)
        {
            return repo.GetAllOrdersByUserIdPriceAsc(id);
        }

        public List<Order> GetAllOrdersByUserIdPriceDesc(int id)
        {
            return repo.GetAllOrdersByUserIdPriceDesc(id);
        }

        public Order GetOrderByDate(DateTime dateTime)
        {
            return repo.GetOrderByDate(dateTime);
        }

        public Order GetOrderById(int id)
        {
            return repo.GetOrderById(id);
        }

        public Order GetOrderByLocationId(int id)
        {
            return repo.GetOrderByLocationId(id);
        }

        public Order GetOrderByUserId(int id)
        {
            return repo.GetOrderByUserId(id);
        }

        public void UpdateOrder(Order order)
        {
            repo.UpdateOrder(order);
        }
    }
}