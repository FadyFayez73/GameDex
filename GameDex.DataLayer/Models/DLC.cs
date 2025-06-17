using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDex.DataLayer.Models
{
    public class DLC
    {
        // Property
        public int DLCID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Game Entity Relation Many to Many
        public int? GameID { get; set; }
        public Game? Game { get; set; }
    }
}
