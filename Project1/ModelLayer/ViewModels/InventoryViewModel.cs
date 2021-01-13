using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.ViewModels
{
    public class InventoryViewModel
    {
        public Guid CustomerId { get; set; }
        public int InventoryId { get; set; }

        public int LocationId { get; set; }

        [Display(Name = "")]
        public string ProductPicture { get; set; }

        [Display(Name = "Product")]
        public string ProductName { get; set; }

        [Range(0, double.MaxValue)]
        public double price { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }


    }
}
