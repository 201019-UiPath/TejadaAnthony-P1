using System;
using System.Collections.Generic;

namespace StoreAppDB.Models
{
    public class Customer
    {
        public int CustomerId { get; set; } //primary key
        public string Name { get; set; } 
        public string Email { get; set; }
        public string Password { get; set; }
        public int Location { get; set; }

        public Cart cart { get; set; }
        public List<Order> order { get; set; }
        


    }
}
