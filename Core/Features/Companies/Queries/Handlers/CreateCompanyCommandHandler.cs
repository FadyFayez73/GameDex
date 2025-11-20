using AutoMapper;
using Core.Features.Companies.Queries.Commands;
using Domain.Entities;
using MediatR;
using Services.Contracts;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Companies.Queries.Handlers
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, (bool, Guid)>
    {
        private readonly ICompanyServices _companyServices;
        private readonly IMapper _mapper;

        public CreateCompanyCommandHandler(ICompanyServices companyServices, IMapper mapper) 
        {
            _companyServices = companyServices;
            _mapper = mapper;
        }

        public async Task<(bool, Guid)> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = _mapper.Map<Company>(request);
            if (company == null)
                throw new ArgumentNullException(nameof(company), "Company domain model cannot be null");

            var result = await _companyServices.AddAsync(company);

            return result;
        }
    }
}