using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.Games
{
    public struct GameForDisplayDto
    {
        public Guid GameID { get; set; }
        public string? Name { get; set; } 
        public string? PGRating { get; set; }
        public decimal UserRating { get; set; }
        public decimal SteamPrices { get; set; }
        public string? CoverUrl { get; set; }
        public List<string>? Genres { get; set; }
        public List<string>? Platforms { get; set; }
    }
}
