using Application.Features.Companies.Queries.Commands;
using Domain.Entities;
using MediatR;
using Application.Contracts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Companies.Queries.Handlers
{
    public class GetCompanyByIdCommandHandler : IRequestHandler<GetCompanyByIdCommand, Company?>
    {
        private readonly ICompanyServices _companyServices;

        public GetCompanyByIdCommandHandler(ICompanyServices companyServices)
        {
            _companyServices = companyServices;
        }

        public async Task<Company?> Handle(GetCompanyByIdCommand request, CancellationToken cancellationToken)
        {
            if (request == null || request.CompanyId == Guid.Empty)
                throw new ArgumentException("Invalid company id.", nameof(request));

            var company = await _companyServices.GetCompanyByIdAsync(request.CompanyId);
            return company;
        }
    }
}