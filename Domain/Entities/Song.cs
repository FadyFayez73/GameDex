using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Song
    {
        // Property
        public Guid SongID { get; set; }
        public string Name { get; set; }
        public int DiscNumber { get; set; }
        public int TrackNumber { get; set; }
        public string Detail { get; set; }

        //Album Entity Relation Many to One
        public Guid AlbumID { get; set; }
        public Album? Album { get; set; }
    }
}
