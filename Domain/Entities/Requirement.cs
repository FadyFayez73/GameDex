using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Requirement
    {
        // Property
        public Guid RequirementID { get; set; }
        public RequirementTypeEnum RequirementType { get; set; }
        public string SystemOS { get; set; }
        public string Processor { get; set; }
        public string Memory { get; set; }
        public string Graphics { get; set; }
        public string Network { get; set; }
        public string Storage { get; set; }
        public string SoundCard { get; set; }
        public string DirectX { get; set; }

        // Game Entity Relation One to Many
        public Guid GameID { get; set; }
        public Game? Game { get; set; }

        public enum RequirementTypeEnum
        {
            Minimum,
            Recommended
        }
    }
}
