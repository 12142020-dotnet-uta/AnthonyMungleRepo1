using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project0
{
    public class Location
    {
    
        [Key]
        public int LocationId { get; set;}
        public string LocationName{ get; set;}
    }
}