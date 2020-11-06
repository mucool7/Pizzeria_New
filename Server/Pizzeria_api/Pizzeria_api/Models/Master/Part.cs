using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzeria_api.Models.Master
{
    public class Part
    {

        public int PartNo { get; set; }
        public string Name { get; set; }
        public Boolean IsImage { get; set; }
        public List<SubPart> SubTypes { get; set; }

    }
}
