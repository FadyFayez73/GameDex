using AutoMapper;
using Core.Features.Companies.Queries.Commands;
using Domain.Entities;
using MediatR;
using Services.Contracts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Features.Companies.Queries.Handlers
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, bool>
    {
        private readonly ICompanyServices _companyServices;
        private readonly IMapper _mapper;

        public UpdateCompanyCommandHandler(ICompanyServices companyServices, IMapper mapper)
        {
            _companyServices = companyServices;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = _mapper.Map<Company>(request);
            if (company == null)
                throw new ArgumentNullException(nameof(company), "Company domain model cannot be null");

            var result = await _companyServices.UpdateAsync(company);
            return result;
        }
    }
}