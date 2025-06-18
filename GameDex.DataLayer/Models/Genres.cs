using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GameDex.DataLayer.Models
{
    public class Genres
    {
        // Property
        public int GenreID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Game Entity Relation Many to Many
        [JsonIgnore]
        public ICollection<Game>? Games { get; set; }

    }
}
