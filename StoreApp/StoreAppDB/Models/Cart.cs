using System;
using System.Collections.Generic;
using System.Text;

namespace StoreAppDB.Models
{
    public class Cart
    {

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer{get; set;}
        public List<CartItem> CartItem { get; set; }
    }
}
