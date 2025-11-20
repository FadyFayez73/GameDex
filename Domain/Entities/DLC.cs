using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DLC
    {
        // Property
        public Guid DLCID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Game Entity Relation Many to Many
        public Guid GameID { get; set; }
        public Game? Game { get; set; }
    }
}
