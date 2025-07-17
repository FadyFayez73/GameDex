using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class FilterModel
    {
        public Checkboxes Checkboxes { get; set; }
        public Range Range { get; set; }
        public string SortBy { get; set; }
    }

    public class Checkboxes
    {
        public List<string> Genres { get; set; }
        public List<string> Platforms { get; set; }
        public List<string> Tags { get; set; }
    }

    public class Range
    {
        public RangeValue Price { get; set; }
        public RangeValue Size { get; set; }
    }

    public class RangeValue
    {
        public decimal Min { get; set; }
        public decimal Max { get; set; }
    }
}
