using Application.Dtos.Genres;
using Application.Features.Genres.Queries.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the GenresController class with the specified mediator.
        /// </summary>
        /// <param name="mediator">The mediator used to send requests and commands within the application. Cannot be null.</param>
        public GenresController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region Gets
        /// <summary>
        /// Retrieves a list of all available genres.
        /// </summary>
        /// <returns>An <see cref="IActionResult"/> containing the collection of genres. The response has a status code of 200
        /// (OK) with the list of genres in the response body.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllGenresAsync()
        {
            var genres = await _mediator.Send(new GetAllGenresCommand());
            return Ok(genres);
        }

        /// <summary>
        /// Retrieves the genre with the specified unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the genre to retrieve. Must not be <see cref="Guid.Empty"/>.</param>
        /// <returns>An <see cref="IActionResult"/> containing the genre data if found; <see cref="NotFoundResult"/> if the genre
        /// does not exist; or <see cref="BadRequestResult"/> if <paramref name="id"/> is empty.</returns>
        [HttpGet("by-id/{id:guid}", Name = "GetGenreById")]
        public async Task<IActionResult> GetGenreByIdAsync(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();
            var genre = await _mediator.Send(new GetGenreByIdCommand(id));
            if (genre == null) return NotFound("The genre is not found");
            return Ok(genre);
        }

        /// <summary>
        /// Retrieves the genre that matches the specified name.
        /// </summary>
        /// <param name="name">The name of the genre to retrieve. Cannot be null or empty.</param>
        /// <returns>An <see cref="IActionResult"/> containing the genre that matches the specified name if found; otherwise, a
        /// Bad Request result if <paramref name="name"/> is null or empty.</returns>
        [HttpGet("by-name/{name}")]
        public async Task<IActionResult> GetGenreByNameAsync(string name)
        {
            if (name == null || name == string.Empty) return BadRequest();
            var genre = await _mediator.Send(new GetGenreByNameCommand(name));
            return Ok(genre);
        }

        /// <summary>
        /// Retrieves a collection of genres that match the specified unique identifiers.
        /// </summary>
        /// <param name="ids">A list of genre IDs to retrieve. Each ID must be a non-empty GUID. The list cannot be empty.</param>
        /// <returns>An HTTP 200 response containing the matching genres if found; otherwise, an HTTP 400 response if the input
        /// is invalid or an HTTP 404 response if no genres are found.</returns>
        [HttpGet("by-ids/{id:guid}")]
        public async Task<IActionResult> GetGenreByIdsAsync(List<Guid> ids)
        {
            if (!ids.Any()) return BadRequest();

            foreach (var id in ids)
                if (id == Guid.Empty) return BadRequest($"Invalid ID in the list : {id}");

            var genre = await _mediator.Send(new GetGenresByIdsCommand(ids));

            if (genre == null)
                return NotFound("Genres not found");

            return Ok(genre);
        }

        /// <summary>
        /// Retrieves one or more genres that match the specified names.
        /// </summary>
        /// <param name="names">A list of genre names to search for. Each name must be a non-empty string.</param>
        /// <returns>An HTTP 200 response containing the matching genres if found; otherwise, an HTTP 400 response if the input
        /// is invalid or an HTTP 404 response if no genres are found.</returns>
        [HttpGet("by-names/{names}")]
        public async Task<IActionResult> GetGenreByGetByNamesAsync(List<string> names)
        {
            if (!names.Any()) return BadRequest();

            foreach (var name in names)
                if (name == string.Empty || name == "") return BadRequest($"Invalid ID in the list : {name}");

            var genre = await _mediator.Send(new GetGenresByNamesCommand(names));

            if (genre == null)
                return NotFound("Genres not found");

            return Ok(genre);
        }

        /// <summary>
        /// Retrieves the list of genres associated with the specified game identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the game for which to retrieve genres. Must not be an empty GUID.</param>
        /// <returns>An HTTP 200 response containing the list of genres if found; an HTTP 404 response if no genres are
        /// associated with the specified game; or an HTTP 400 response if the provided identifier is invalid.</returns>
        [HttpGet("by-game/{id}")]
        public async Task<IActionResult> GetGenresByGameIdAsync(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();
            var genres = await _mediator.Send(new GetGenresByGameIdCommand(id));
            if (genres == null || !genres.Any()) return NotFound("No genres found for this game");
            return Ok(genres);
        }
        #endregion

        #region Actions
        /// <summary>
        /// Creates a new genre using the specified command.
        /// </summary>
        /// <param name="command">The command containing the details of the genre to create. Cannot be null.</param>
        /// <returns>A 201 Created response with the created genre if successful; a 409 Conflict response if the genre already
        /// exists; or a 400 Bad Request response if the command is null.</returns>
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateGenreCommand command)
        {
            if (command == null) return BadRequest();
            var (state, id) = await _mediator.Send(command);
            if (!state) return StatusCode(StatusCodes.Status409Conflict, "The genre is already exist");
            var genre = new GenreDto
            {
                GenreID = id,
                Name = command.Name,
                Description = command.Description
            };
            return CreatedAtAction(
                "GetGenreById",
                new { id = genre.GenreID },
                genre
            );
        }

        /// <summary>
        /// Updates the details of an existing genre using the specified update command.
        /// </summary>
        /// <param name="command">The command containing the updated genre information. Must not be null, and the GenreID must not be empty.</param>
        /// <returns>An <see cref="IActionResult"/> indicating the result of the update operation. Returns <see
        /// cref="OkObjectResult"/> with the result if the update succeeds; <see cref="BadRequestResult"/> if the
        /// command is invalid; or <see cref="ObjectResult"/> with status code 409 if the update fails.</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateGenreCommand command)
        {
            if (command == null || command.GenreID == Guid.Empty) return BadRequest();

            var result = await _mediator.Send(command);

            if (!result) return StatusCode(StatusCodes.Status409Conflict, "Update fail");

            return Ok(result);
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();

            var result = await _mediator.Send(new DeleteGenreCommand(id));

            if (!result) return StatusCode(StatusCodes.Status404NotFound, "The genre already is not exist");

            return NoContent();
        }
        #endregion
    }
}