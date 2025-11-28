using Application.Dtos.Characters;
using Application.Features.Characters.Queries.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class CharactersController : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator;
        #endregion

        #region Constructors
        public CharactersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region Gets
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

        [HttpGet("by-game/{gameId}")]
        public async Task<ActionResult<IEnumerable<CharacterDto>>> GetCharactersByGameId(Guid gameId)
        {
            var command = new GetCharactersByGameIdCommand { GameId = gameId };
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        #endregion

        #region Actions
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
        #endregion
    }
}