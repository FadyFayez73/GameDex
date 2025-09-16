using Core.Dtos.Companies;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace Core.Features.Companies.Queries.Commands
{
    public class GetAllCompaniesCommand : IRequest<IEnumerable<CompanyDto>>
    {
    }
}