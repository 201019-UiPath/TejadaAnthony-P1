using System.Net.Mime;
using System.Collections.Generic;
namespace StoreAppDB.Models
{
    public class Location
    {
        public int id { get; set; } //primary key
        public string name { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postalCode { get; set; }
        public List<Inventory> Inventory { get; set; }



    }
}