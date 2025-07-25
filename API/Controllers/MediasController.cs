using Core.Features.Medias.Queries.Commands;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MediasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetMediaById/{id}")]
        public async Task<IActionResult> GetMediaByIdAsync(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();
            var Media = await _mediator.Send(new GetMediaByIdCommand(id));
            if (Media == null) return NotFound();
            return Ok(Media);
        }

        [HttpGet("GetMediaById")]
        public async Task<IActionResult> GetMediaByIdFromQueryAsync([FromQuery] Guid id)
        {
            if (id == Guid.Empty) return BadRequest();
            var Media = await _mediator.Send(new GetMediaByIdCommand(id));
            if (Media == null) return NotFound();
            return Ok(Media);
        }

        [HttpGet("ByGame/{id}")]
        public async Task<IActionResult> GetMediaByGameIdAsync(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();
            var Media = await _mediator.Send(new GetMediasByGameIdCommand(id));
            if (Media == null) return NotFound();
            return Ok(Media);
        }

        [HttpGet("ByGame")]
        public async Task<IActionResult> GetMediaByGameIdFromQueryAsync([FromQuery] Guid id)
        {
            if (id == Guid.Empty) return BadRequest();
            var Media = await _mediator.Send(new GetMediasByGameIdCommand(id));
            if (Media == null) return NotFound();
            return Ok(Media);
        }

        [HttpPost]
        public async Task<IActionResult> AddMediaAsync([FromBody] CreateMediaCommand media)
        {
            if (media == null) return BadRequest();
            var (state, id) = await _mediator.Send(media);
            if (!state) return StatusCode(StatusCodes.Status409Conflict, "This media is already exists");
            return Created();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateMediaCommand Media)
        {
            if (Media == null) return BadRequest();
            var result = await _mediator.Send(Media);
            if (!result) return NotFound();
            return Ok("media has been updated");
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteFromQueryAsync([FromQuery] Guid id)
        {
            if (id == Guid.Empty) return BadRequest();
            var result = await _mediator.Send(new DeleteMediaCommand(id));
            if (!result) return NotFound();
            return Ok("media has been deleted");
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();
            var result = await _mediator.Send(new DeleteMediaCommand(id));
            if (!result) return NotFound();
            return Ok("media has been deleted");
        }

    }
}