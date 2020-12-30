using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project0
{
    public class Location
    {
    
        [Key]
        public int LocationId { get; set;} //The Primary Key for the datatable represented in an int
        public string LocationName{ get; set;} // The name displayed in the store
    }
}