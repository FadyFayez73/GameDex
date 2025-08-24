using Core.Features.Genres.Queries.Commands;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GenresController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGenresAsync()
        {
            var genres = await _mediator.Send(new GetAllGenresCommand());
            return Ok(genres);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetGenreByIdFromQueryAsync([FromQuery] Guid id)
        {
            if (id == Guid.Empty) return BadRequest();

            var genre = await _mediator.Send(new GetGenreByIdCommand(id));

            if (genre == null)
                return NotFound("Genre not found");

            return Ok(genre);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetGenreByIdAsync(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();
            var genre = await _mediator.Send(new GetGenreByIdCommand(id));
            return Ok(genre);
        }

        [HttpGet("GetByName")]
        public async Task<IActionResult> GetGenreByNameFromQueryAsync([FromQuery] string name)
        {
            if (name == null || name == string.Empty) return BadRequest();
            var genre = await _mediator.Send(new GetGenreByNameCommand(name));
            return Ok(genre);
        }

        [HttpGet("GetByName/{name}")]
        public async Task<IActionResult> GetGenreByNameAsync(string name)
        {
            if (name == null || name == string.Empty) return BadRequest();
            var genre = await _mediator.Send(new GetGenreByNameCommand(name));
            return Ok(genre);
        }

        [HttpGet("GetByIds")]
        public async Task<IActionResult> GetGenreByIdsFromQueryAsync([FromQuery] List<Guid> ids)
        {
            if (!ids.Any()) return BadRequest();

            foreach (var id in ids)
                if (id == Guid.Empty) return BadRequest($"Invalid ID in the list : {id}");

            var genre = await _mediator.Send(new GetGenresByIdsCommand(ids));

            if (genre == null)
                return NotFound("Genres not found");

            return Ok(genre);
        }

        [HttpGet("GetByIds/{id}")]
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

        [HttpGet("GetByNames")]
        public async Task<IActionResult> GetGenreByGetByNamesFromQueryAsync([FromQuery] List<string> names)
        {
            if (!names.Any()) return BadRequest();

            foreach (var name in names)
                if (name == string.Empty || name == "") return BadRequest($"Invalid ID in the list : {name}");

            var genre = await _mediator.Send(new GetGenresByNamesCommand(names));

            if (genre == null)
                return NotFound("Genres not found");

            return Ok(genre);
        }

        [HttpGet("GetByNames/{id}")]
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

        [HttpGet("GetByGameId")]
        public async Task<IActionResult> GetGenreByGameIdFromQueryAsync([FromQuery] Guid id)
        {
            if (id == Guid.Empty) return BadRequest();
            var genres = await _mediator.Send(new GetGenresByGameIdCommand(id));
            if (genres == null || !genres.Any()) return NotFound("No genres found for this game");
            return Ok(genres);
        }

        [HttpGet("GetByGameId/{id}")]
        public async Task<IActionResult> GetGenresByGameIdAsync(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();
            var genres = await _mediator.Send(new GetGenresByGameIdCommand(id));
            if (genres == null || !genres.Any()) return NotFound("No genres found for this game");
            return Ok(genres);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateGenreCommand command)
        {
            if (command == null) return BadRequest();
            var (state, id) = await _mediator.Send(command);
            if(!state) return StatusCode(StatusCodes.Status409Conflict, "The genre is already exist");
            return Created();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateGenreCommand command)
        {
            if(command == null || command.GenreID == Guid.Empty) return BadRequest();

            var result = await _mediator.Send(command);

            if(!result) return StatusCode(StatusCodes.Status409Conflict, "Update fail");

            return Ok(result);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteFromQueryAsync([FromQuery] Guid id)
        {
            if(id == Guid.Empty) return BadRequest();

            var result = await _mediator.Send(new DeleteGenreCommand(id));

            if (!result) return StatusCode(StatusCodes.Status404NotFound, "The genre is already not exist");

            return NoContent();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();

            var result = await _mediator.Send(new DeleteGenreCommand(id));

            if (!result) return StatusCode(StatusCodes.Status404NotFound, "The genre is already not exist");

            return NoContent();
        }
    }
}
