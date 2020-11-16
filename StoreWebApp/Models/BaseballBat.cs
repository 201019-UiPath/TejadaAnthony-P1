using System.ComponentModel;

namespace StoreWebApp.Models
{
    public class BaseballBat
    {
        [DisplayName("Id")]
        public int Id { get; set; } //primary key
        [DisplayName("Name")]
        public string ProductName { get; set; }
        [DisplayName("Price")]
        public decimal ProductPrice { get; set; }
        [DisplayName("Type")]
        public string ProductType { get; set; }


    }
}