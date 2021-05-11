using System;
using System.Collections.Generic;

namespace StoreAppDB.Models
{
    public class Bat
    { 
        public int id { get; set; } //primary key
        public string product{ get; set; }
        public float price { get; set; }
        public string description { get; set; }
        public batType type { get; set; }

        public enum batType
        {
            metal,
            wood,
        }


    }
}