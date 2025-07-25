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
