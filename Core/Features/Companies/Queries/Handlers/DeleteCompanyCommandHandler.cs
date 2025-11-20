using Core.Features.Companies.Queries.Commands;
using MediatR;
using Services.Contracts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Features.Companies.Queries.Handlers
{
    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand, bool>
    {
        private readonly ICompanyServices _companyServices;

        public DeleteCompanyCommandHandler(ICompanyServices companyServices)
        {
            _companyServices = companyServices;
        }

        public async Task<bool> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            if (request == null || request.CompanyId == Guid.Empty)
                throw new ArgumentException("Invalid company id.", nameof(request));

            var result = await _companyServices.DeleteAsync(request.CompanyId);
            return result;
        }
    }
}