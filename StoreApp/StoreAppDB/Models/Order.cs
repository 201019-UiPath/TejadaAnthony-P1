using System;
using System.Data.SqlTypes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace StoreAppDB.Models
{
    public class Order
    {

        public int id { get; set; }
        public int userId { get; set; }
        public User user { get; set; }
        public int locationId { get; set; }
        public Location location { get; set; }
        public DateTime orderDate { get; set; }
        public double totalPrice { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}