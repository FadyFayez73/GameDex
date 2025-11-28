using Application.Dtos.Companies;
using Application.Features.Companies.Queries.Commands;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompaniesController : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator;
        #endregion

        #region Constructors
        public CompaniesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region Gets
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Company?>> GetById(Guid id)
        {
            var command = new GetCompanyByIdCommand(id);
            var company = await _mediator.Send(command);
            if (company == null)
                return NotFound();
            return Ok(company);
        }

        [HttpGet("by-name/{name}")]
        public async Task<ActionResult<Company?>> GetByName(string name)
        {
            var command = new GetCompanyByNameCommand(name);
            var company = await _mediator.Send(command);
            if (company == null)
                return NotFound();
            return Ok(company);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyDto>>> GetAll()
        {
            var command = new GetAllCompaniesCommand();
            var companies = await _mediator.Send(command);
            return Ok(companies);
        }

        [HttpGet("by-game/{gameId:guid}")]
        public async Task<ActionResult<IEnumerable<Company>>> GetByGameId(Guid gameId)
        {
            var command = new GetCompaniesByGameIdCommand(gameId);
            var companies = await _mediator.Send(command);
            return Ok(companies);
        }

        #endregion

        #region Actions
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCompanyCommand command)
        {
            if (command == null) return BadRequest();
            var (state, id) = await _mediator.Send(command);
            if (!state) return StatusCode(StatusCodes.Status409Conflict, "The Company is already exist");
            var company = new Company
            {
                CompanyID = id,
                Name = command.Name,
                Description = command.Description,
            };
            return CreatedAtAction(nameof(GetById), new { id = id }, company);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCompanyCommand command)
        {
            if (id != command.CompanyId)
                return BadRequest("Company ID mismatch.");
            var result = await _mediator.Send(command);
            if (!result)
                return NotFound("Company not found or update failed.");
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteCompanyCommand { CompanyId = id };
            var result = await _mediator.Send(command);
            if (!result)
                return NotFound("Company not found or delete failed.");
            return NoContent();
        }
        #endregion
    }
}