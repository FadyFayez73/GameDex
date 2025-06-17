using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDex.DataLayer.Models
{
    public class Performance
    {
        // Property
        public int PerformanceID { get; set; }
        public string GraphicsQuality { get; set; }
        public int Low1PercentFPS { get; set; }
        public string AverageFPS { get; set; }
        public string MaxFPS { get; set; }
        public string TestDate { get; set; }

        // Game Entity Relation Many to One
        public int? GameID { get; set; }
        public Game? Game { get; set; }
    }
}
