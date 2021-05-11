using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using StoreAppDB.Models;
using StoreAppDB;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace StoreAppDB
{
    public class StoreAppContext : DbContext
    {

        public StoreAppContext(DbContextOptions<StoreAppContext> options) : base(options){ }
        
        //entities

        public DbSet<User> Users {get;set;}
        public DbSet<Inventory> Inventories {get;set;}
        public DbSet<Location> Locations {get;set;}
        public DbSet<Bat> Bats {get;set;}
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var batConverter = new EnumToStringConverter<Bat.batType>();
            var userConverter = new EnumToStringConverter<User.userType>();

            modelBuilder.Entity<Bat>()
            .Property(b => b.type)
            .HasConversion(batConverter);

            modelBuilder.Entity<User>()
            .Property(u => u.type)
            .HasConversion(userConverter);

        }
    }
}