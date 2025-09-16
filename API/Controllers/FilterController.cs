using Core;
using Core.Features.Filters.Queries.Commands;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.ServicesDto.Filter;
using System.Text.Json;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FilterController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FilterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("GetByFilter")]
        public async Task<IActionResult> Filter([FromBody] FilterModel filter)
        {
            if (filter == null)
                return BadRequest("Filter cannot be null");

            var games = await _mediator.Send(new GetFilteredGamesCommand(filter));

            
            return Ok(games.ToList());
        }

        //[HttpGet("GetData")]
        //public async Task<IActionResult> GetAllGames()
        //{
        //    var json = new
        //    {
        //        id = 1,
        //        name = "fady",
        //        skills = new string[] { "C#", "JavaScript", "Python", "jQuery", "HTML5", "CSS3", "SCSS", "React", "ASP.NET Core Web API", "ASP.NET Core MVC", "Entity Framework Core", "TypeScript", "WinForms" },
        //    };
        //    var jsonString = await Task.Run(() => JsonSerializer.Serialize(json));
        //    return Ok(jsonString);
        //}
    }
}
