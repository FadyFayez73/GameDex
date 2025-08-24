using Core.Features.Characters.Queries.Commands;
using Core.Dtos.Characters;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CharactersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CharactersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterDto>>> GetAllCharacters()
        {
            var command = new GetAllCharactersCommand();
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterDto>> GetCharacterById(Guid id)
        {
            var command = new GetCharacterByIdCommand { CharacterId = id };
            var result = await _mediator.Send(command);
            
            if (result == null)
                return NotFound();
                
            return Ok(result);
        }

        [HttpGet("game/{gameId}")]
        public async Task<ActionResult<IEnumerable<CharacterDto>>> GetCharactersByGameId(Guid gameId)
        {
            var command = new GetCharactersByGameIdCommand { GameId = gameId };
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<(bool, Guid)>> AddCharacter([FromBody] CreateCharacterCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.Item1)
            {
                return CreatedAtAction(nameof(GetCharacterById), new { id = result.Item2 }, result);
            }
            return BadRequest("Failed to create character");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> UpdateCharacter(Guid id, [FromBody] UpdateCharacterCommand command)
        {
            if (id != command.CharacterId)
                return BadRequest("ID mismatch");

            var result = await _mediator.Send(command);
            if (result)
                return Ok(result);
                
            return NotFound("Character not found");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteCharacter(Guid id)
        {
            var command = new DeleteCharacterCommand { CharacterId = id };
            var result = await _mediator.Send(command);
            
            if (result)
                return Ok(result);
                
            return NotFound("Character not found");
        }
    }
}
