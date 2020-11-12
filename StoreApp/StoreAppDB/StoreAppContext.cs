using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using StoreAppDB.Models;
using StoreAppDB;

namespace StoreAppDB
{
    public class StoreAppContext : DbContext
    {

        public StoreAppContext(DbContextOptions<StoreAppContext> options) : base(options){ }
        
        //entities

        public DbSet<Manager> Managers {get;set;}
        public DbSet<Customer> Customers {get;set;}
        public DbSet<Inventory> Inventory {get;set;}
        public DbSet<Location> Locations {get;set;}
        public DbSet<BaseballBat> BaseballBats {get;set;}
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }


    }
}