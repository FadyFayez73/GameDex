using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Character
    {
        // Property
        public Guid CharacterID { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }

        //Game Entity Relation Many to One
        public Guid GameID { get; set; }
        public Game? Game { get; set; }

        //Character Entity Relation Many to Many
        public ICollection<ChapterMission>? ChapterMissions { get; set; }
    }
}
