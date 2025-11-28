using Application.Features.Companies.Queries.Commands;
using MediatR;
using Application.Contracts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Companies.Queries.Handlers
{
    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand, bool>
    {
        private readonly ICompanyApplication _companyApplication;

        public DeleteCompanyCommandHandler(ICompanyApplication companyApplication)
        {
            _companyApplication = companyApplication;
        }

        public async Task<bool> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            if (request == null || request.CompanyId == Guid.Empty)
                throw new ArgumentException("Invalid company id.", nameof(request));

            var result = await _companyApplication.DeleteAsync(request.CompanyId);
            return result;
        }
    }
}