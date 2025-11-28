using Application.Dtos.Companies;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace Application.Features.Companies.Queries.Commands
{
    public class GetAllCompaniesCommand : IRequest<IEnumerable<CompanyDto>>
    {
    }
}