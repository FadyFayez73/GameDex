using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDex.DataLayer.Models
{
    public class ChapterMission
    {
        // Property
        public int ChapterMissionID { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //Game Entity Relation Many to One
        public int? GameID { get; set; }
        public Game? Game { get; set; }

        //Character Entity Relation Many to Many
        public ICollection<Character>? Characters { get; set; }
    }
}