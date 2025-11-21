using Core.Features.Albums.Queries.Commands;
using Core.Dtos.Albums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Domain.Entities;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlbumsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AlbumsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAlbumCommand command)
        {
            if (command == null) return BadRequest();
            var (state, id) = await _mediator.Send(command);
            if (!state) return StatusCode(StatusCodes.Status409Conflict, "The Album already exists");
            var album = await _mediator.Send(new GetAlbumByIdCommand(id));
            return CreatedAtAction(nameof(GetById), new { id = id }, album);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateAlbumCommand command)
        {
            if (id != command.AlbumId)
                return BadRequest("Album ID mismatch.");
            var result = await _mediator.Send(command);
            if (!result)
                return NotFound("Album not found or update failed.");
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteAlbumCommand { AlbumId = id };
            var result = await _mediator.Send(command);
            if (!result)
                return NotFound("Album not found or delete failed.");
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlbumDto>>> GetAll()
        {
            var command = new GetAllAlbumsCommand();
            var albums = await _mediator.Send(command);
            return Ok(albums);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Album?>> GetById(Guid id)
        {
            var command = new GetAlbumByIdCommand(id);
            var album = await _mediator.Send(command);
            if (album == null)
                return NotFound();
            return Ok(album);
        }

        [HttpGet("by-name/{name}")]
        public async Task<ActionResult<Album?>> GetByName(string name)
        {
            var command = new GetAlbumByNameCommand(name);
            var album = await _mediator.Send(command);
            if (album == null)
                return NotFound();
            return Ok(album);
        }

        [HttpGet("by-game/{gameId:guid}")]
        public async Task<ActionResult<IEnumerable<Album>>> GetByGameId(Guid gameId)
        {
            var command = new GetAlbumsByGameIdCommand(gameId);
            var albums = await _mediator.Send(command);
            return Ok(albums);
        }

        [HttpGet("by-genre/{generName}")]
        public async Task<ActionResult<IEnumerable<Album>>> GetByGenreName(string generName)
        {
            var command = new GetAlbumsByGenreCommand(generName);
            var albums = await _mediator.Send(command);
            return Ok(albums);
        }
    }
}