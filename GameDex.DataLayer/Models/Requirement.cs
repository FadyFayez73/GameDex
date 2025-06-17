using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDex.DataLayer.Models
{
    public class Requirement
    {
        // Property
        public int RequirementID { get; set; }
        public string RequirementType { get; set; }
        public string SystemOS { get; set; }
        public string Processor { get; set; }
        public string Memory { get; set; }
        public string Graphics { get; set; }
        public string Network { get; set; }
        public string Storage { get; set; }
        public string SoundCard { get; set; }
        public string DirectX { get; set; }

        // Game Entity Relation One to Many
        public int? GameID { get; set; }
        public Game? Game { get; set; }
    }
}
