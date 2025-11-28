using MediatR;
using Domain.Entities;
using System;

namespace Application.Features.Companies.Queries.Commands
{
    public class GetCompanyByIdCommand : IRequest<Company?>
    {
        public Guid CompanyId { get; set; }

        public GetCompanyByIdCommand(Guid companyId)
        {
            CompanyId = companyId;
        }
    }
}