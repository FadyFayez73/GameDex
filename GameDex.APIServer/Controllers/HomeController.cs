using GameDex.DataLayer;
using GameDex.Tools.DataHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameDex.APIServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private GamesHelper _gamesHelper;

        public HomeController(AppDbContext context)
        {
            _gamesHelper = new GamesHelper(context);
        }


        [HttpGet("top-ten")]
        public async Task<IActionResult> GetTopTen()
        {
            return Ok(await _gamesHelper.GetGamesWithIncludes());
        }

        [HttpGet("last-games")]
        public async Task<IActionResult> GetLastGames()
        {
            return Ok(await _gamesHelper.GetLatestGamesAsync());
        }
    }
}
