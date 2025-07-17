using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Core.Features.Games.Queries.Commands;

namespace GameDex.APIServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public GamesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllGamesForDisplay")]
        public async Task<IActionResult> GetAllGamesForDisplayAsync()
        {
            var games = await _mediator.Send(new GetAllGamesForDisplayCommand());
            if (games == null || !games.Any()) return NotFound();
            return Ok(games);
        }

        //[HttpPost("GetGame/{id}")]
        //public async Task<IActionResult> GetGameForDisplayAsync(int id)
        //{
        //    if (id == 0) return BadRequest();
        //    var game = await _mapper
        //    if (game == null) return NotFound();
        //    return Ok(game);
        //}
    }
}
