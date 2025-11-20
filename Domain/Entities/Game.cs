using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Game
    {
        // Property
        public Guid GameID { get; set; }
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
        public ICollection<Album> Albums { get; set; } = new List<Album>();
        public ICollection<Control> Controls { get; set; } = new List<Control>();
        public ICollection<Requirement> Requirements { get; set; } = new List<Requirement>();
        public ICollection<CompanyGame> CompanyGames { get; set; } = new List<CompanyGame>();
        public ICollection<ModManager> ModManagers { get; set; } = new List<ModManager>();
        public ICollection<Media> Medias { get; set; } = new List<Media>();
        public ICollection<Platform> Platforms { get; set; } = new List<Platform>();
        public ICollection<ChapterMission> ChapterMissions { get; set; } = new List<ChapterMission>();
        public ICollection<Character> Characters { get; set; } = new List<Character>();
        public ICollection<Performance> Performances { get; set; } = new List<Performance>();
        public ICollection<Genre> Genres { get; set; } = new List<Genre>();
        public ICollection<DLC> DLCs { get; set; } = new List<DLC>();
    }
}