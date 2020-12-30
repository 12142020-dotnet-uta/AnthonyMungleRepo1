using System;
using System.ComponentModel.DataAnnotations;

namespace Project0
{
    public class Order
    {
        private Guid orderId = Guid.NewGuid(); //Creates a new Guid For CustomerId
        [Key]//Sets the below to be the key for the database
        public Guid OrderId { get{return orderId;} set {orderId = value;}} //Sets a public Guid to the above guid and returns the value
        public Customer Customer {get; set;}
        public Location Location {get; set;}
        public string ProductName {get; set;}
        //Use public product
        public double Price {get; set;}
        public int Amount {get; set;}

    }
}