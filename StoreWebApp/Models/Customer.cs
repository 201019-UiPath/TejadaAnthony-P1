
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebApp.Models
{
    public class Customer
    {
        public Customer()
        {
            cart = new Cart();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public int Location { get; set; }

        public Cart cart { get; set; }
        public List<Order> order { get; set; }
    }
}
