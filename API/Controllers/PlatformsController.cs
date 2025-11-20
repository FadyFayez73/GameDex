using Core.Dtos.Platforms;
using Core.Features.Platforms.Queries.Commands;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlatformsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PlatformsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePlatformCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.Item1)
                return BadRequest("Failed to create platform.");
            return CreatedAtAction(nameof(GetById), new { id = result.Item2 }, result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdatePlatformCommand command)
        {
            if (id != command.PlatformId)
                return BadRequest("Platform ID mismatch.");
            var result = await _mediator.Send(command);
            if (!result)
                return NotFound("Platform not found or update failed.");
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeletePlatformCommand { PlatformId = id };
            var result = await _mediator.Send(command);
            if (!result)
                return NotFound("Platform not found or delete failed.");
            return NoContent();
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<PlatformDto?>> GetById(Guid id)
        {
            var command = new GetPlatformByIdCommand(id);
            var platform = await _mediator.Send(command);
            if (platform == null)
                return NotFound();
            return Ok(platform);
        }

        [HttpGet("by-name/{name}")]
        public async Task<ActionResult<PlatformDto?>> GetByName(string name)
        {
            var command = new GetPlatformByNameCommand(name);
            var platform = await _mediator.Send(command);
            if (platform == null)
                return NotFound();
            return Ok(platform);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlatformDto>>> GetAll()
        {
            var command = new GetAllPlatformsCommand();
            var platforms = await _mediator.Send(command);
            return Ok(platforms);
        }
    }
}