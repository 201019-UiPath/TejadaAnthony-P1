using System;
using System.Collections.Generic;
using StoreAppDB.Interfaces;
using StoreAppDB.Models;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace StoreAppDB
{
    public class DBRepo : IUserRepoActions, IBatRepoActions, ILocationRepoActions, IOrderRepoActions, IInventoryRepoActions, ICartRepoActions, ICartItemRepoActions, IOrderItemRepoActions
    {
        private StoreAppContext context;
        public DBRepo(StoreAppContext context)
        {
            this.context = context;
        }
     

        // Bat Repo Methods Being Implemented
        public void AddBat(Bat bat){
            context.Bats.Add(bat);
            context.SaveChanges();
        }

        public void UpdateBat(Bat bat){
            context.Bats.Update(bat);
            context.SaveChanges();
        }

        public void DeleteBat(Bat bat){
            context.Bats.Remove(bat);
            context.SaveChanges();
        }

        public Bat GetBatById(int id){
            return context.Bats.SingleOrDefault(d => d.id == id);
        }

        public Bat GetBatByName(string name){
            return context.Bats.Single(x => x.product == name);
        }
        public List<Bat> GetAllBats(){
            return context.Bats.Select(x => x).ToList();
        }


        //User Repo Methods Being Implemented
        public void AddUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            context.Users.Update(user);
            context.SaveChanges();
        }

        public User GetUserById(int id)
        {
            return context.Users.Single(x => x.id == id);
        }

        public User GetUserByEmail(string email)
        {
            return context.Users.Single(x => x.email == email);
        }

        public List<User> GetAllUsers()
        {
            return context.Users.Select(x => x).ToList();
        }

        public void DeleteUser(User user)
        {
            context.Users.Remove(user);
            context.SaveChanges();
        }

        //Locations Repo Methods Being Implemented
        public void AddLocation(Location location)
        {
            context.Locations.Add(location);
            context.SaveChanges();
        }
        public void UpdateLocation(Location location)
        {
            context.Locations.Update(location);
            context.SaveChanges();
        }
        public Location GetLocationById(int id)
        {
            return context.Locations.Single(x => x.id == id);
        }
        public Location GetLocationByState(string state)
        {
            return context.Locations.Single(x => x.state == state);
        }
        public List<Location> GetAllLocations()
        {
            return context.Locations.Select(x => x).ToList();
        }
        public void DeleteLocation(Location location)
        {
            context.Locations.Remove(location);
            context.SaveChanges();
        }

        //Inventory Repo Methods Being Implemented
        public void AddInventoryItem(Inventory inventory)
        {
            context.Inventories.Add(inventory);
            context.SaveChanges();
        }
        public void UpdateInventoryItem(Inventory inventory)
        {
            context.Inventories.Update(inventory);
            context.SaveChanges();
        }
        public Inventory GetInventoryItemById(int id)
        {
            return context.Inventories.Single(x => x.id == id);
        }
        public List<Inventory> GetAllInventoryItemsById(int id)
        {
            return context.Inventories.Where(x => x.id == id).ToList();
        }
        public Inventory GetInventoryItemByLocationId(int id)
        {
            return context.Inventories.Single(x => x.locationId == id);
        }
        public List<Inventory> GetAllInventoryItemsByLocationId(int id)
        {
            return context.Inventories.Select(x => x).Where(x => x.locationId == id).ToList();
        }
        public void DeleteInventoryItem(Inventory inventory)
        {
            context.Inventories.Remove(inventory);
            context.SaveChanges();
        }
        public Inventory GetItemByLocationIdBatId(int locationId, int batId)
        {
            return context.Inventories.Single(x => x.locationId == locationId && x.batId == batId);
        }


        //orders
        public void AddOrder(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            context.Orders.Update(order);
            context.SaveChanges();
        }

        public Order GetOrderById(int id)
        {
            return context.Orders.Single(x => x.id == id);
        }

        public Order GetOrderByUserId(int id)
        {
            return context.Orders.Single(x => x.userId == id);
        }

        public Order GetOrderByLocationId(int id)
        {
            return context.Orders.Single(x => x.locationId == id);
        }

        public List<Order> GetAllOrdersByLocationId(int id)
        {
            return context.Orders.Where(x => x.locationId == id).ToList();
        }

        public List<Order> GetAllOrdersByUserId(int id)
        {
            return context.Orders.Where(x => x.userId == id).ToList();
        }

        public void DeleteOrder(Order order)
        {
            context.Orders.Remove(order);
            context.SaveChanges();
        }

        public List<Order> GetAllOrdersByUserIdDateAsc(int id)
        {
            return context.Orders.Where(x => x.userId == id).OrderBy(x => x.orderDate).ToList();
        }
        public List<Order> GetAllOrdersByUserIdDateDesc(int id)
        {
            return context.Orders.Where(x => x.userId == id).OrderByDescending(x => x.orderDate).ToList();
        }
        public List<Order> GetAllOrdersByUserIdPriceAsc(int id)
        {
            return context.Orders.Where(x => x.userId == id).OrderBy(x => x.totalPrice).ToList();
        }
        public List<Order> GetAllOrdersByUserIdPriceDesc(int id)
        {
            return context.Orders.Where(x => x.userId == id).OrderByDescending(x => x.totalPrice).ToList();
        }
        public Order GetOrderByDate(DateTime dateTime)
        {
            return (Order)context.Orders.Single(x => x.orderDate == dateTime);
        }

        public List<Order> GetAllOrdersByLocationIdDateAsc(int id)
        {
            return context.Orders.Where(x => x.locationId == id).OrderBy(x => x.orderDate).ToList();
        }
        public List<Order> GetAllOrdersByLocationIdDateDesc(int id)
        {
            return context.Orders.Where(x => x.locationId == id).OrderByDescending(x => x.orderDate).ToList();
        }
        public List<Order> GetAllOrdersByLocationIdPriceAsc(int id)
        {
            return context.Orders.Where(x => x.locationId == id).OrderBy(x => x.totalPrice).ToList();
        }
        public List<Order> GetAllOrdersByLocationIdPriceDesc(int id)
        {
            return context.Orders.Where(x => x.locationId == id).OrderByDescending(x => x.totalPrice).ToList();
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
            return context.OrderItems.SingleOrDefault(x => x.id == id);
        }
        public List<OrderItem> GetAllOrderItemsByOrderId(int id)
        {
            return context.OrderItems.Where(x => x.orderId == id).ToList(); ;
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
            return context.Carts.Single(x => x.id == id);
        }
        public Cart GetCartByUserId(int id)
        {
            return context.Carts.SingleOrDefault(x => x.userId == id);
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
            return context.CartItems.SingleOrDefault(x => x.id == id);
        }
        public CartItem GetCartItemByCartId(int id)
        {
            return context.CartItems.SingleOrDefault(x => x.cartId == id);
        }
        public List<CartItem> GetAllCartItemsByCartId(int id)
        {
            return context.CartItems.Where(x => x.cartId == id).ToList();
        }
        public void DeleteCartItem(CartItem cart)
        {
            context.CartItems.Remove(cart);
            context.SaveChanges();
        }

     
    }
}