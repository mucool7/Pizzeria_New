using Pizzeria_api.DataLayer;
using Pizzeria_api.Models.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzeria_api.BusinessLayer
{
    public partial class BusinessLogic
    {

        private DataAdapter adapter;

        public BusinessLogic()
        {
            adapter = new DataAdapter();
        }

        public List<SubPart> GetSubParts()
        {
            List<SubPart> subParts = adapter.GetData<List<SubPart>>(DataPaths.SubParts);
            return subParts;
        }

        public List<Part> GetParts()
        {
            List<Part> part = adapter.GetData<List<Part>>(DataPaths.Parts);
            return part;
        }

        public List<Part> GetPartsWithSubType()
        {
            List<Part> parts = adapter.GetData<List<Part>>(DataPaths.Parts);
            List<SubPart> subParts =GetSubParts();

            foreach(Part part in parts)
            {
                part.SubTypes = new List<SubPart>();
                part.SubTypes = subParts.Where(x => x.PartNo == part.PartNo).ToList();
            }

            return parts;
        }
    }
}
