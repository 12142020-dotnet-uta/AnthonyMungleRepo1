using System;
using System.ComponentModel.DataAnnotations;

namespace Project0
{
    public class Cart
    {
        private Guid cartId = Guid.NewGuid();
        [Key]//Sets the below to be the key for the database
        public Guid CartId { get{return cartId;} set {cartId = value;}}
        public Product Product { get; set;}
        public Customer Owner {get; set;}
        public int amount {get; set;}

    } ////POPULATE THE DATABASE!!!!!!!!!!!
}