using System.ComponentModel.DataAnnotations;

namespace Project1
{
    public class Inventory
    {
        [Key]
        public int InventoryId { get;set;}
        public Location Location { get; set;}
        public Product Product { get; set;}
        public int Quantity { get; set;}
    }
}