using System;
using System.Collections.Generic;
using System.Text;

namespace StoreAppDB.Models
{
    public class CartItem
    {
        public int id { get; set; }
        public int cartId { get; set; }
        public Cart Cart { get; set; }
        public int batId { get; set; }
        public Bat bat { get; set; }
        public int quantity { get; set; }
    }
}
