using Application.Features.Medias.Queries.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MediasController : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator;
        #endregion

        #region Constructors
        public MediasController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region Gets
        [HttpGet("{id}", Name = "GetMediaById")]
        public async Task<IActionResult> GetMediaByIdAsync(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();
            var Media = await _mediator.Send(new GetMediaByIdCommand(id));
            if (Media == null) return NotFound();
            return Ok(Media);
        }

        [HttpGet("by-game/{id}")]
        public async Task<IActionResult> GetMediaByGameIdAsync(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();
            var Media = await _mediator.Send(new GetMediasByGameIdCommand(id));
            if (Media == null) return NotFound();
            return Ok(Media);
        }
        #endregion

        #region Actions
        [HttpPost]
        public async Task<IActionResult> AddMediaAsync([FromBody] CreateMediaCommand media)
        {
            if (media == null) return BadRequest();
            var (state, id) = await _mediator.Send(media);
            if (!state) return StatusCode(StatusCodes.Status409Conflict, "This media is already exists");
            var mediaExists = await _mediator.Send(new GetMediaByIdCommand(id));
            return CreatedAtAction("GetMediaById", new { id }, mediaExists);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateMediaCommand Media)
        {
            if (Media == null) return BadRequest();
            var result = await _mediator.Send(Media);
            if (!result) return NotFound();
            return Ok("media has been updated");
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();
            var result = await _mediator.Send(new DeleteMediaCommand(id));
            if (!result) return NotFound();
            return Ok("media has been deleted");
        }
        #endregion
    }
}