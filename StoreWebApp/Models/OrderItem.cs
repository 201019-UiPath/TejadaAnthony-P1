using StoreWebApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StoreWebApp.Models
{
    public class OrderItem
    {
 
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int BaseballBatId { get; set; }
        public BaseballBat BaseballBat { get; set; }
        public decimal Quantity { get; set; }

        public decimal Cost { get; set; }
    }
}
