﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StoreAppDB.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        public int BaseballBatId { get; set; }
        public BaseballBat BaseballBat { get; set; }
        public int Quantity { get; set; }
    }
}
