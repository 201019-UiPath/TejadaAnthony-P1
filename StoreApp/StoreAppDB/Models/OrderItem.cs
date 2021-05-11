using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StoreAppDB.Models
{
    public class OrderItem
    {
        [Key]
        public int id { get; set; }
        public int orderId { get; set; }
        public Order Order { get; set; }
        public int batId { get; set; }
        public Bat bat { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }
    }
}
