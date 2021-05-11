using System;
using System.Collections.Generic;
using System.Text;

namespace StoreAppDB.Models
{
    public class Cart
    {

        public int id { get; set; }
        public int userId { get; set; }
        public User user{get; set;}
        public List<CartItem> CartItems { get; set; }
    }
}
