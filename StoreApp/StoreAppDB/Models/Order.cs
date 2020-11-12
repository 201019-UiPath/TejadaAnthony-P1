using System;
using System.Data.SqlTypes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace StoreAppDB.Models
{
    public class Order
    {
       
        [Key]
        public int  Id { get; set; } //Primary key
        public string OrderDate { get; set; }

        public Location Location { get; set; }
        public int LocationId{get; set; }

        public Customer Customer { get; set; }
        public int CustomerId{get; set; }
        public int Total { get; set; }
        public List<OrderItem> OrderItem { get; set; }
    }
}