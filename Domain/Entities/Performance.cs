using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Performance
    {
        // Property
        public Guid PerformanceID { get; set; }
        public string GraphicsQuality { get; set; }
        public int Low1PercentFPS { get; set; }
        public string AverageFPS { get; set; }
        public string MaxFPS { get; set; }
        public string TestDate { get; set; }

        // Game Entity Relation Many to One
        public Guid GameID { get; set; }
        public Game? Game { get; set; }
    }
}
