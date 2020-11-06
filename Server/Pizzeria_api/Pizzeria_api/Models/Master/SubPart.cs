using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzeria_api.Models.Master
{
    public class SubPart
    {
        public int PartNo { get; set; }
        public int SubPartNo { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }

    }
}
