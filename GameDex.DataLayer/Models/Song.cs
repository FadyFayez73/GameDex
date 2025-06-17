using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDex.DataLayer.Models
{
    public class Song
    {
        // Property
        public int SongID { get; set; }
        public string Name { get; set; }
        public int DiscNumber { get; set; }
        public int TrackNumber { get; set; }
        public string Detail { get; set; }

        //Album Entity Relation Many to One
        public int? AlbumID { get; set; }
        public Album? Album { get; set; }
    }
}
