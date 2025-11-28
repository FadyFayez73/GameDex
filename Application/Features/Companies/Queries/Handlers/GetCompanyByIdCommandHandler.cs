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
        private readonly ICompanyApplication _companyApplication;

        public GetCompanyByIdCommandHandler(ICompanyApplication companyApplication)
        {
            _companyApplication = companyApplication;
        }

        public async Task<Company?> Handle(GetCompanyByIdCommand request, CancellationToken cancellationToken)
        {
            if (request == null || request.CompanyId == Guid.Empty)
                throw new ArgumentException("Invalid company id.", nameof(request));

            var company = await _companyApplication.GetCompanyByIdAsync(request.CompanyId);
            return company;
        }
    }
}