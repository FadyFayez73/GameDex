using GameDex.DataLayer.Models;
using GameDex.Core.DataHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GameDex.Core;
using Microsoft.EntityFrameworkCore;

namespace GameDex.APIServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly GamesHelper _games;
        public LibraryController(GamesHelper games)
        {
            _games = games;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var games = await _games.GetAllAsync();
            return Ok(games);
        }

        [HttpGet("GetAllForDisplay")]
        public async Task<IActionResult> GetAllForDisplayAsync()
        {
            var game = await _games.GetAllForDisplayAsync();
            return Ok(game);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Game game)
        {
            if (game == null)
                return BadRequest("Game cannot be null");

            _games.Add(game);

            var getSearch = await _games.AdvancedSearchAsync(game.Name);
            var getGame = getSearch.FirstOrDefault(g => g.Name == game.Name);

            if (getGame == null)
                return NotFound("Game not found after creation");
            return Created($"ID: {getGame.GameID}", getGame);
        }

        [HttpPost("Filter")]
        public async Task<IActionResult> Filter(FilterModel filter)
        {
            if (filter == null)
                return BadRequest("Filter cannot be null");

            var games = await _games.GetAllForDisplayAsync();

            if(filter.Checkboxes != null)
            {
                if (filter.Checkboxes.Genres != null && filter.Checkboxes.Genres.Count > 0)
                    games = games.Where(g => g.Genres.Any(g => filter.Checkboxes.Genres.Contains(g.Name)));
                if (filter.Checkboxes.Platforms != null && filter.Checkboxes.Platforms.Count > 0)
                    games = games.Where(g => g.Platforms.Any(p => filter.Checkboxes.Platforms.Contains(p.Name)));
            }
            var f1 = await games.ToListAsync();

            if (filter.Range != null)
            {
                if (filter.Range.Price.Max != 0 && filter.Range.Price.Min >= 0)
                    games = games.Where(g => g.SteamPrices >= filter.Range.Price.Min && g.SteamPrices <= filter.Range.Price.Max);
            }

            var f2 = await games.ToListAsync();


            if (!string.IsNullOrEmpty(filter.SortBy))
            {
                switch (filter.SortBy.ToLower())
                {
                    case "name":
                        games = games.OrderBy(g => g.Name);
                        break;
                    case "year":
                        games = games.OrderBy(g => g.YearOfRelease);
                        break;
                    case "price":
                        games = games.OrderBy(g => g.SteamPrices);
                        break;
                    default:
                        return BadRequest("Invalid sort option");
                }
            }
            var f3 = await games.ToListAsync();
            return Ok(games.ToList());
        }
    }
}