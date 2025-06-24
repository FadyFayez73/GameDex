using GameDex.DataLayer.Models;
using GameDex.Tools.DataHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Create([FromBody] Game game)
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
    }
}