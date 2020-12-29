
using System;
using System.ComponentModel.DataAnnotations;

namespace Project0
{
    public class Product
    {

        [Key]
        public string ProductName { get; set;}
        public double Price { get; set; }
        public string Description{ get; set;}
        
    }
}