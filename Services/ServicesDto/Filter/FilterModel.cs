using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServicesDto.Filter
{
    public class FilterModel
    {
        public CheckboxFilters Checkboxes { get; set; }
        public RangeFilters Range { get; set; }
        public string SortBy { get; set; }

    }
}
