using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzeria_api.Models
{
    public class Order
    {
        public int OrderNo { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public List<Product> Products { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
