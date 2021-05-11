using System.Net.Http.Headers;
namespace StoreAppDB.Models
{
    public class Inventory
    {
        public int id { get; set; } // primary key
        public int batId { get; set; }
        public Bat bats { get; set; }
        public int quantity{ get; set; }
        public int locationId { get; set; }
        public Location Location{get; set; }
    


    }
}