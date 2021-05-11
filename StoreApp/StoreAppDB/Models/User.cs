using System;
using System.Collections.Generic;

namespace StoreAppDB.Models
{
    public class User
    {
        public int id { get; set; } //primary key
        public string name { get; set; } 
        public string email { get; set; }
        public string password { get; set; }
        public userType type { get; set; }
        public int locationId { get; set; }
        public Location location { get; set; }
        public Cart cart { get; set; }
        public List<Order> orders { get; set; }

        public enum userType
        {
            Customer,
            Manager,
        }



    }
}
