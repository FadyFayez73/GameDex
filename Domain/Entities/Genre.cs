using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Genre
    {
        // Property
        public Guid GenreID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Game Entity Relation Many to Many
        public ICollection<Game> Games { get; set; }

    }
}
