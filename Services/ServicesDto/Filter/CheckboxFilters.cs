using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServicesDto.Filter
{
    public class CheckboxFilters
    {
        public List<string> Genres { get; set; }
        public List<string> Platforms { get; set; }
        public List<string> Tags { get; set; }
    }
}
