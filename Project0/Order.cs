using System;
using System.ComponentModel.DataAnnotations;

namespace Project0
{
    public class Order
    {
        private Guid orderId = Guid.NewGuid(); //Creates a new Guid For OrderId
        [Key]//Sets the below to be the key for the database
        public Guid OrderId { get{return orderId;} set {orderId = value;}} //Sets a public Guid to the above guid and returns the value
        public Customer Customer {get; set;}//Will be a FK to the customer datatable
        public Location Location {get; set;}//Will be a Fk to the Location dataTable
        public string ProductName {get; set;}//A string representing the Product in the column
        public double Price {get; set;}//The price of the entire order
        public int Amount {get; set;}//the amount of the products in the order

    }
}