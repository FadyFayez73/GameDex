using GameDex.DataLayer;
using GameDex.Core.DataHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameDex.APIServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly GamesHelper _games;
        public GamesController(GamesHelper games)
        {
            _games = games;
        }

        [HttpPost("GetGame/{id}")]
        public async Task<IActionResult> GetGameForDisplayAsync(int id)
        {
            if (id == 0) return BadRequest();
            var game = await _games.GetGameForDisplayAsync(id);
            if (game == null) return NotFound();
            return Ok(game);
        }
    }
}
