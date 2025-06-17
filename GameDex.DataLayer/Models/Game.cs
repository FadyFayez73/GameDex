using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDex.DataLayer.Models
{
    public class Game
    {
        // Property
        public int GameID { get; set; }
        public string Name { get; set; }
        public string Patch { get; set; }
        public string GamePath { get; set; }
        public string YearOfRelease { get; set; }
        public string PGRating { get; set; }
        public string GameDescription { get; set; }
        public string GameEngine { get; set; }
        public string OrderOfFranchise { get; set; }
        public string LinkForCrack { get; set; }
        public decimal CriticsRating { get; set; }
        public decimal PlayersRating { get; set; }
        public decimal UserRating { get; set; }
        public decimal SteamPrices { get; set; }
        public string ActualGameSize { get; set; }
        public string GameFiles { get; set; }
        public int HoursToComplete { get; set; }
        public int PlayerHours { get; set; }
        public string StoryPlace { get; set; }

        // Many to Many Relation
        public ICollection<Album>? Albums { get; set; }
        public ICollection<Control>? Controls { get; set; }
        public ICollection<Requirement>? Requirements { get; set; }
        public ICollection<Company>? Companies { get; set; }
        public ICollection<ModManager> ModManagers { get; set; }
        public ICollection<Media>? Medias { get; set; }
        public ICollection<Platform>? Platforms { get; set; }
        public ICollection<ChapterMission>? ChapterMissions { get; set; }
        public ICollection<Character>? Characters { get; set; }
        public ICollection<Performance>? Performances { get; set; }
        public ICollection<Genres>? Genres { get; set; }
        public ICollection<DLC>? DLCs { get; set; }
    }
}