using System;
using System.Collections.Generic;
using StoreAppDB.Interfaces;
using StoreAppDB.Models;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace StoreAppDB
{
    public class DBRepo : IManagerRepoActions, ICustomerRepoActions, IBaseballBatRepoActions, ILocationRepoActions, IOrderRepoActions, IInventoryRepoActions, ICartRepoActions, ICartItemRepoActions, IOrderItemRepoActions
    {
        private StoreAppContext context;
        public DBRepo(StoreAppContext context)
        {
            this.context = context;
        }
        //BaseballBat

        public void AddBaseballBatIntoTableAsync(BaseballBat baseballbat)
        {
            context.BaseballBats.Add(baseballbat);
            context.SaveChanges();

        }
        public BaseballBat GetBaseballBatById(int id)
        {
            return context.BaseballBats.SingleOrDefault(d => d.Id == id);
        }
        public List<BaseballBat> GetAllBaseballBats()
        {
            return context.BaseballBats.Select(x => x).ToList();
        }

        public void UpdateBaseballBat(BaseballBat bat)
        {
            context.BaseballBats.Update(bat);
            context.SaveChanges();
        }

        public void DeleteBaseballBat(BaseballBat bat)
        {
            context.BaseballBats.Remove(bat);
            context.SaveChanges();
        }

        //Manager
        public void AddManager(Manager manager)
        {
            context.Managers.Add(manager);
            context.SaveChanges();
        }
        public List<Manager> GetAllManagers()
        {
            return context.Managers.Select(x => x).ToList();
        }
        public bool CheckIfManagerExists(string email, string password)
        {
            var result = context.Managers.Any(o => o.Email == email && o.password == password);

            return result;
        }

        //Customer
        public List<Customer> GetAllCustomers() {

            return context.Customers.Select(x => x).ToList();
        }
        public bool CheckIfCustomerExists(string email, string password)
        {
            var result = context.Customers.Any(o => o.Email == email && o.Password == password);

            return result;
        }

        public void AddCustomerIntoTable(Customer newCustomer)
        {
            context.Customers.Add(newCustomer);
            context.SaveChanges();
        }

        public Customer GetCustomerByEmail(string email)
        {
            var result = context.Customers.SingleOrDefault(d => d.Email == email);

            return result;
        }

        //locations
        public List<Location> GetAllLocations()
        {
            return context.Locations.Select(x => x).Include("Manager").ToList();
        }

        public Location GetLocationById(int locationId)
        {
            var result = context.Locations.SingleOrDefault(d => d.LocationId == locationId);

            return result;
        }
        //inventory 
        public void UpdateInventoryQuantity(Inventory inventory)
        {
            var result =context.Inventory.SingleOrDefault(a => a.InventoryId == inventory.InventoryId);
            result.Quantity = inventory.Quantity;
            context.SaveChanges();
            
        }
        public List<Inventory> GetInventoryByLocationId(int id)
        {
            return context.Inventory.Select(x => x).Where(x => x.LocationId==id).ToList();
        }
        public Inventory GetInventoryRecordByInventoryNumber(int id)
        {
            return context.Inventory.SingleOrDefault(f => f.InventoryId == id);
             
        }
        //orders
        public void AddOrderToTable(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
        }

        public List<Order> GetOrdersByLocationId(int locationId)
        {
            return context.Orders.Select(x => x).Where(x => x.LocationId == locationId).ToList();
        }

        public List<Order> GetOrdersByCustomerId(int cusId)
        {
            return context.Orders.Select(x => x).Where(x => x.CustomerId == cusId).ToList();
        }
        //OrderItem
        public void AddOrderItem(OrderItem OrderItem)
        {
            context.OrderItems.Add(OrderItem);
            context.SaveChanges();
        }
        public void UpdateOrderItem(OrderItem OrderItem)
        {
            context.OrderItems.Update(OrderItem);
            context.SaveChanges();
        }
        public OrderItem GetOrderItemByOrderId(int id)
        {
            return context.OrderItems.SingleOrDefault(x => x.OrderId == id);
        }
        public List<OrderItem> GetAllOrderItemsByOrderId(int id)
        {
            return context.OrderItems.Where(x => x.OrderId == id).ToList(); ;
        }
        public void DeleteOrderItem(OrderItem OrderItem)
        {
            context.OrderItems.Remove(OrderItem);
            context.SaveChanges();
        }

        //Cart 
        public void AddCart(Cart cart)
        {
            context.Carts.Add(cart);
            context.SaveChanges();
        }
        public void UpdateCart(Cart cart)
        {
            context.Carts.Update(cart);
            context.SaveChanges();
        }
        public Cart GetCartById(int id)
        {
            return context.Carts.SingleOrDefault(x => x.Id == id);
        }
        public Cart GetCartByCustomerId(int id)
        {
            return context.Carts.SingleOrDefault(x => x.CustomerId == id);
        }
        public void DeleteCart(Cart cart)
        {
            context.Carts.Remove(cart);
            context.SaveChanges();
        }

        //Cart Items
        public void AddCartItem(CartItem cart)
        {
            context.CartItems.Add(cart);
            context.SaveChanges();
        }
        public void UpdateCartItem(CartItem cartItem)
        {
            context.CartItems.Update(cartItem);
            context.SaveChanges();
        }
        public CartItem GetCartItemById(int id)
        {
            return context.CartItems.SingleOrDefault(x => x.Id == id);
        }
        public CartItem GetCartItemByCartId(int id)
        {
            return context.CartItems.SingleOrDefault(x => x.CartId == id);
        }
        public List<CartItem> GetAllCartItemsByCartId(int id)
        {
            return context.CartItems.Where(x => x.CartId == id).ToList();
        }
        public void DeleteCartItem(CartItem cart)
        {
            context.CartItems.Remove(cart);
            context.SaveChanges();
        }

    }
}