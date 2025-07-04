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

        [HttpPost("GetGame")]
        public async Task<IActionResult> GetGameForDisplayAsync([FromBody] int id)
        {
            if (id == 0) return BadRequest();
            return Ok(await _games.GetGameForDisplayAsync(id));
        }
    }
}
