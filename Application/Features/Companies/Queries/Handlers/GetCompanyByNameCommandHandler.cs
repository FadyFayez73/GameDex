using Application.Features.Companies.Queries.Commands;
using Domain.Entities;
using MediatR;
using Application.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Companies.Queries.Handlers
{
    public class GetCompanyByNameCommandHandler : IRequestHandler<GetCompanyByNameCommand, Company?>
    {
        private readonly ICompanyServices _companyServices;

        public GetCompanyByNameCommandHandler(ICompanyServices companyServices)
        {
            _companyServices = companyServices;
        }

        public async Task<Company?> Handle(GetCompanyByNameCommand request, CancellationToken cancellationToken)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Name))
                throw new ArgumentException("Invalid company name.", nameof(request));

            var company = await _companyServices.GetCompanyByNameAsync(request.Name);
            return company;
        }
    }
}