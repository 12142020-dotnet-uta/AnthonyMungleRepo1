using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.ViewModels
{
    public class CartViewModel
    {
        public Guid customerGuid { get; set;}
        public Guid CartId { get; set; }
        public int locationsId { get; set; }

        public string ProductName { get; set; }
        public double total { get; set; }

    }
}
