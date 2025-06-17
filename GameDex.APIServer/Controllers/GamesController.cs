using GameDex.DataLayer;
using GameDex.Tools.DataHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameDex.APIServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private GamesHelper _gamesHelper;

        public GamesController(AppDbContext context)
        {
            _gamesHelper = new GamesHelper(context);
        }


        [HttpGet("top-ten")]
        public async Task<IActionResult> Index()
        {
            return Ok(_gamesHelper.)
        }
    }
}
