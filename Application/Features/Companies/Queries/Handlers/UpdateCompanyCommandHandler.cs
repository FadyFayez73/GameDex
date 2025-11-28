using AutoMapper;
using Application.Features.Companies.Queries.Commands;
using Domain.Entities;
using MediatR;
using Application.Contracts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Companies.Queries.Handlers
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, bool>
    {
        private readonly ICompanyApplication _companyApplication;
        private readonly IMapper _mapper;

        public UpdateCompanyCommandHandler(ICompanyApplication companyApplication, IMapper mapper)
        {
            _companyApplication = companyApplication;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = _mapper.Map<Company>(request);
            if (company == null)
                throw new ArgumentNullException(nameof(company), "Company domain model cannot be null");

            var result = await _companyApplication.UpdateAsync(company);
            return result;
        }
    }
}