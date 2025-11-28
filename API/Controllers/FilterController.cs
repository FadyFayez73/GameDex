using Application.Features.Filters.Queries.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Dtos.Filter;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FilterController : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator;
        #endregion

        #region Constructors
        public FilterController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region Actions
        [HttpPost]
        public async Task<IActionResult> Filter([FromBody] FilterModel filter)
        {
            if (filter == null)
                return BadRequest("Filter cannot be null");

            var games = await _mediator.Send(new GetFilteredGamesCommand(filter));


            return Ok(games.ToList());
        }
        #endregion
    }
}