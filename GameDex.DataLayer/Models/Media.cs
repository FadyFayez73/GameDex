using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GameDex.DataLayer.Models
{
    public class Media
    {
        // Property
        public int MediaID { get; set; }
        public string MediaType { get; set; }
        public string MediaPath { get; set; }

        // Game Entity Relation Many to One
        public int? GameID { get; set; }

        [JsonIgnore]
        public Game? Game { get; set; }
    }
}
