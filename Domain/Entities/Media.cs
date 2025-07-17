using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Media
    {
        // Property
        public Guid MediaID { get; set; }
        public string MediaType { get; set; }
        public string MediaPath { get; set; }

        // Game Entity Relation Many to One
        public Guid GameID { get; set; }
        public Game? Game { get; set; }
    }
}
