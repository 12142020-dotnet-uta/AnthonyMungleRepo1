using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.ViewModels
{
    public class OrderViewModel
    {

        public Guid OrderId { get; set; }

        public string ProductName { get; set; }

        public double Price { get; set; }

        public int Amount { get; set; }

        public DateTime? Date { get; set; }
    }
}
