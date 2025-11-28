using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Filter
{
    public class RangeFilters
    {
        public RangeModel Price { get; set; } = new RangeModel();
        public RangeModel Size { get; set; } = new RangeModel();
    }
}
