
using System;
using System.ComponentModel.DataAnnotations;

namespace Project0
{
    public class Product
    {
        [Key]
        public string ProductName { get; set;}//The primary Key for the Product database
        public double Price { get; set; } //will be te amount that the Product costs
        public string Description{ get; set;}//A brief Discrition of the product
        
    }
}