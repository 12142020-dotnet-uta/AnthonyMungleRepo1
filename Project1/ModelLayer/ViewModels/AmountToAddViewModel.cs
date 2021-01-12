using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.ViewModels
{
    public class AmountToAddViewModel
    {
        public Guid CustomerId { get; set; }
        //public Guid CartId { get; set; } 
        public int inventory { get; set; }
        public String Product { get; set; }
        //public Customer Owner { get; set; }
        public int location { get; set; }
        public string discription { get; set; }
        public string JpgString { get; set; }

        public int stock { get; set; }
        
        [Range(0, 20)]
        public int amount { get; set; }


    }
}
