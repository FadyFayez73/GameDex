using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Core.Features.Games.Queries.Commands;

namespace API.Controllers
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

        [HttpGet]
        public async Task<IActionResult> GetAllGamesForDisplayAsync()
        {
            var games = await _mediator.Send(new GetAllGamesForDisplayCommand());
            if (games == null || !games.Any()) return NotFound();
            return Ok(games);
        }

        [HttpGet("Display/{id}")]
        public async Task<IActionResult> GetGameForDisplayAsync(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();
            var game = await _mediator.Send(new GetGameForDisplayCommand(id));
            if (game == null) return NotFound();
            return Ok(game);
        }

        [HttpGet("Display")]
        public async Task<IActionResult> GetGameForDisplayFromQueryAsync([FromQuery] Guid id)
        {
            if (id == Guid.Empty) return BadRequest();
            var game = await _mediator.Send(new GetGameForDisplayCommand(id));
            if (game == null) return NotFound();
            return Ok(game);
        }

        [HttpGet("Details/{id}")]
        public async Task<IActionResult> GetGameDetailsAsync(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();
            var game = await _mediator.Send(new GetGameByIdCommand(id));
            if (game == null) return NotFound();
            return Ok(game);
        }

        [HttpGet("Details")]
        public async Task<IActionResult> GetGameDetailsFromQueryAsync([FromQuery] Guid id)
        {
            if (id == Guid.Empty) return BadRequest();
            var game = await _mediator.Send(new GetGameByIdCommand(id));
            if (game == null) return NotFound();
            return Ok(game);
        }

        [HttpPost]
        public async Task<IActionResult> AddGameAsync([FromBody] CreateGameCommand game)
        {
            if (game == null) return BadRequest();
            var (state, id) = await _mediator.Send(game);
            if (!state) return StatusCode(StatusCodes.Status409Conflict, "This game is already exists");
            return Created();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateGameCommand game)
        {
            if (game == null) return BadRequest();
            var result = await _mediator.Send(game);
            if (!result) return NotFound();
            return Ok("Game has been updated");
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteFromQuery([FromQuery] Guid id)
        {
            if (id == Guid.Empty) return BadRequest();
            var result = await _mediator.Send(new DeleteGameCommand(id));
            if (!result) return NotFound();
            return Ok("Game has been deleted");
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();
            var result = await _mediator.Send(new DeleteGameCommand(id));
            if (!result) return NotFound();
            return Ok("Game has been deleted");
        }
    }
}