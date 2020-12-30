using System;
using System.ComponentModel.DataAnnotations;

namespace Project0
{
    public class Cart
    {
        private Guid cartId = Guid.NewGuid();//Creates a Guid that will be inserted into the PK
        [Key]//Sets the below to be the key for the database
        public Guid CartId { get{return cartId;} set {cartId = value;}}//The Pk of the datatable
        public Product Product { get; set;} //The FK to Product table
        public Customer Owner {get; set;}// The FK to the Customer Table
        public int amount {get; set;} // The amount that the product costs in the datatable

    } 
}