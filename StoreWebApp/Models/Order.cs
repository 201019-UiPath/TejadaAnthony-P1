using System;
using System.Data.SqlTypes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using StoreWebApp.Models;

namespace StoreWebApp.Models
{
    public class Order
    {
       
     
        public int  Id { get; set; } //Primary key
        public DateTime OrderDate { get; set; }

        public Location Location { get; set; }
        public int LocationId{get; set; }

        public Customer Customer { get; set; }
        public int CustomerId{get; set; }
        public decimal Total { get; set; }
        public List<OrderItem> OrderItem { get; set; }
    }
}