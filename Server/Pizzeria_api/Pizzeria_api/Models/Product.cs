using Pizzeria_api.Models.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzeria_api.Models
{
    public class Product
    {
        public int ProductNo { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int ProductType { get; set; }
        public List<Part> Parts { get;set; } 
        public decimal TotalPrice { get; set; }
    }
}
