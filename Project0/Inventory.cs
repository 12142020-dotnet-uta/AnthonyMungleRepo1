using System.ComponentModel.DataAnnotations;

namespace Project0
{
    public class Inventory
    {
        [Key]
        public int InventoryId { get;set;} //An int represent the primary key
        public Location Location { get; set;}//The FK to the Location datatable
        public Product Product { get; set;}//The FK to the Product datatabe
        public int Quantity { get; set;} // The quantity of each product in the inventory list
    }
}