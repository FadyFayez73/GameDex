//using Core;
//using Domain.Entities;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System.Text.Json;

//namespace API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class FilterController : ControllerBase
//    {
//        private readonly GamesHelper _games;
//        public FilterController(GamesHelper games)
//        {
//            _games = games;
//        }

//        [HttpPost("SetFilterData")]
//        public async Task<IActionResult> Filter([FromBody] FilterModel filter)
//        {
//            if (filter == null)
//                return BadRequest("Filter cannot be null");

//            var games = await _games.GetAllForDisplayAsync();

//            if (filter.Checkboxes != null)
//            {
//                if (filter.Checkboxes.Genres != null && filter.Checkboxes.Genres.Count > 0)
//                    games = games.Where(g => g.Genres.Any(g => filter.Checkboxes.Genres.Contains(g.Name)));
//                if (filter.Checkboxes.Platforms != null && filter.Checkboxes.Platforms.Count > 0)
//                    games = games.Where(g => g.Platforms.Any(p => filter.Checkboxes.Platforms.Contains(p.Name)));
//            }

//            if (filter.Range != null)
//            {
//                if (filter.Range.Price.Max != 0 && filter.Range.Price.Min >= 0)
//                    games = games.Where(g => g.SteamPrices >= filter.Range.Price.Min && g.SteamPrices <= filter.Range.Price.Max);
//            }

//            if (!string.IsNullOrEmpty(filter.SortBy))
//            {
//                switch (filter.SortBy)
//                {
//                    case "name":
//                        games = games.OrderByDescending(g => g.Name);
//                        break;
//                    case "release":
//                        games = games.OrderByDescending(g => g.YearOfRelease);
//                        break;
//                    case "priceLowerToHigher":
//                        games = games.OrderBy(g => g.SteamPrices);
//                        break;
//                    case "priceHigherToLower":
//                        games = games.OrderByDescending(g => g.SteamPrices);
//                        break;
//                    case "sizeLowerToHigher":
//                        games = games.OrderBy(g => g.ActualGameSize);
//                        break;
//                    case "sizeHigherToLower":
//                        games = games.OrderByDescending(g => g.ActualGameSize);
//                        break;
//                    default:
//                        return BadRequest("Invalid sort option");
//                }
//            }
//            return Ok(games.ToList());
//        }

//        [HttpGet("GetData")]
//        public async Task<IActionResult> GetAllGames()
//        {
//            var json = new {
//                id = 1,
//                name = "fady",
//                skills = new string[] { "C#", "JavaScript", "Python", "jQuery", "HTML5", "CSS3", "SCSS", "React", "ASP.NET Core Web API", "ASP.NET Core MVC", "Entity Framework Core", "TypeScript", "WinForms"},
//            };
//            var jsonString = await Task.Run(() => JsonSerializer.Serialize(json));
//            return Ok(jsonString);
//        }
//    }
//}
