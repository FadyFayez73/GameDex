using Application.Features.Companies.Queries.Commands;
using Domain.Entities;
using MediatR;
using Application.Contracts;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Companies.Queries.Handlers
{
    public class GetCompaniesByGameIdCommandHandler : IRequestHandler<GetCompaniesByGameIdCommand, IEnumerable<Company>>
    {
        private readonly ICompanyApplication _companyApplication;

        public GetCompaniesByGameIdCommandHandler(ICompanyApplication companyApplication)
        {
            _companyApplication = companyApplication;
        }

        public async Task<IEnumerable<Company>> Handle(GetCompaniesByGameIdCommand request, CancellationToken cancellationToken)
        {
            if (request == null || request.GameId == Guid.Empty)
                throw new ArgumentException("Invalid game id.", nameof(request));

            var companies = await _companyApplication.GetCompaniesByGameIdAsync(request.GameId);
            return companies;
        }
    }
}