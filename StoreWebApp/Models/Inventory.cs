using System.ComponentModel;
using System.Net.Http.Headers;
namespace StoreWebApp.Models { 
    public class Inventory
    {
        public int InventoryId { get; set; } // primary key
        [DisplayName("Id")]
        public int BaseballBatsId { get; set; }
        public BaseballBat BaseballBats { get; set; }
        public int Quantity{ get; set; }
        public int LocationId { get; set; }
        public Location Location{get; set; }
    


    }
}