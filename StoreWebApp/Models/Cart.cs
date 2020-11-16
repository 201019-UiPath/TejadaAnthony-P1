using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StoreWebApp.Models
{
    public class Cart
    {
        public Cart()
        {
            CartItem = new List<CartItem>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        [DataType(DataType.Currency)]
        public decimal Total { get; set; }
        public List<CartItem> CartItem { get; set; }
    }
}
