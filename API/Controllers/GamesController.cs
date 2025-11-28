using API.Models;
using Core.Features.Games.Queries.Commands;
using Infrastructure.Context;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator;
        #endregion

        #region Constructors
        public GamesController(IMediator mediator, AppDbContext context)
        {
            _mediator = mediator;
        }
        #endregion

        #region Gets

        /// <summary>
        /// Retrieves a collection of games formatted for display.
        /// </summary>
        /// <returns>An <see cref="IActionResult"/> containing the list of games for display if any exist; otherwise, a NotFound
        /// result if no games are available.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllGamesForDisplayAsync()
        {
            var games = await _mediator.Send(new GetAllGamesForDisplayCommand());
            if (games == null || !games.Any()) return NotFound();
            return Ok(games);
        }

        /// <summary>
        /// Retrieves the game data for display by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the game to retrieve. Must not be <see cref="Guid.Empty"/>.</param>
        /// <returns>An <see cref="IActionResult"/> containing the game data if found; <see cref="NotFoundResult"/> if the game
        /// does not exist; or <see cref="BadRequestResult"/> if <paramref name="id"/> is empty.</returns>
        [HttpGet("Display/{id}")]
        public async Task<IActionResult> GetGameForDisplayAsync(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();
            var game = await _mediator.Send(new GetGameForDisplayCommand(id));
            if (game == null) return NotFound();
            return Ok(game);
        }

        /// <summary>
        /// Retrieves the details of a game with the specified unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the game to retrieve. Must not be <see cref="Guid.Empty"/>.</param>
        /// <returns>An <see cref="IActionResult"/> containing the game details if found; <see cref="NotFoundResult"/> if no game
        /// exists with the specified identifier; or <see cref="BadRequestResult"/> if <paramref name="id"/> is empty.</returns>
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> GetGameDetailsAsync(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();
            var game = await _mediator.Send(new GetGameByIdCommand(id));
            if (game == null) return NotFound();
            return Ok(game);
        }

        /// <summary>
        /// Retrieves a collection of games that belong to the specified genre.
        /// </summary>
        /// <param name="id">The unique identifier of the genre for which to retrieve games. Must not be <see cref="Guid.Empty"/>.</param>
        /// <returns>An <see cref="IActionResult"/> containing the list of games for the specified genre. Returns <see
        /// cref="OkObjectResult"/> with the games if found; <see cref="NotFoundResult"/> if no games exist for the
        /// genre; or <see cref="BadRequestResult"/> if <paramref name="id"/> is invalid.</returns>
        [HttpGet("GetByGenreId/{id}")]
        public async Task<IActionResult> GetGamesByGenreIdAsync(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();
            var games = await _mediator.Send(new GetGamesByGenreIdCommand(id));
            if (games == null || !games.Any()) return NotFound();
            return Ok(games);
        }

        /// <summary>
        /// Retrieves a list of games that belong to the specified genre.
        /// </summary>
        /// <param name="id">The unique identifier of the genre to filter games by. Must not be an empty GUID.</param>
        /// <returns>An HTTP 200 OK response containing the list of games if any are found; an HTTP 404 Not Found response if no
        /// games are found for the specified genre; or an HTTP 400 Bad Request response if the provided genre ID is
        /// empty.</returns>
        [HttpGet("GetByGenreId")]
        public async Task<IActionResult> GetGamesByGenreIdFromQueryAsync([FromQuery] Guid id)
        {
            if (id == Guid.Empty) return BadRequest();
            var games = await _mediator.Send(new GetGamesByGenreIdCommand(id));
            if (games == null || !games.Any()) return NotFound();
            return Ok(games);
        }
        #endregion

        #region Actions
        /// <summary>
        /// Creates a new game using the data provided in the request.
        /// </summary>
        /// <param name="game">The request containing the details of the game to create, including the cover image and game name. Must not
        /// be null, and the cover image must be provided.</param>
        /// <returns>An <see cref="IActionResult"/> that represents the result of the create operation. Returns a 201 Created
        /// response if the game is successfully created; a 400 Bad Request if required data is missing; or a 409
        /// Conflict if the game already exists.</returns>
        [HttpPost]
        public async Task<IActionResult> AddGameAsync([FromForm] CreateGameRequest game)
        {
            if (game.Cover == null) return BadRequest("Game sending without cover!");

            var command = new CreateGameCommand
            {
                Name = game.Name,

            };

            var d = new MemoryStream();

            await game.Cover.CopyToAsync(command.Cover);

            if (game == null) return BadRequest();
            var (state, id) = await _mediator.Send(command);
            if (!state) return StatusCode(StatusCodes.Status409Conflict, "This game is already exists");
            return Created();
        }

        /// <summary>
        /// Updates an existing game with the specified details.
        /// </summary>
        /// <param name="game">An <see cref="UpdateGameCommand"/> object containing the updated information for the game. Cannot be null.</param>
        /// <returns>An <see cref="IActionResult"/> that represents the result of the update operation. Returns <see
        /// cref="OkObjectResult"/> if the update is successful, <see cref="NotFoundResult"/> if the game does not
        /// exist, or <see cref="BadRequestResult"/> if the input is invalid.</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateGameCommand game)
        {
            if (game == null) return BadRequest();
            var result = await _mediator.Send(game);
            if (!result) return NotFound();
            return Ok("Game has been updated");
        }

        /// <summary>
        /// Deletes the game with the specified unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the game to delete. Cannot be <see cref="Guid.Empty"/>.</param>
        /// <returns>An <see cref="IActionResult"/> indicating the result of the delete operation. Returns <see
        /// cref="OkObjectResult"/> if the game was deleted; <see cref="NotFoundResult"/> if the game does not exist; or
        /// <see cref="BadRequestResult"/> if the identifier is invalid.</returns>
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();
            var result = await _mediator.Send(new DeleteGameCommand(id));
            if (!result) return NotFound();
            return Ok("Game has been deleted");
        }
        #endregion
    }
}