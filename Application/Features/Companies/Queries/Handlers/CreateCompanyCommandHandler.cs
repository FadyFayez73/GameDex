using AutoMapper;
using Application.Features.Companies.Queries.Commands;
using Domain.Entities;
using MediatR;
using Application.Contracts;
using Application.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Companies.Queries.Handlers
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, (bool, Guid)>
    {
        private readonly ICompanyApplication _companyApplication;
        private readonly IMapper _mapper;

        public CreateCompanyCommandHandler(ICompanyApplication companyApplication, IMapper mapper) 
        {
            _companyApplication = companyApplication;
            _mapper = mapper;
        }

        public async Task<(bool, Guid)> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = _mapper.Map<Company>(request);
            if (company == null)
                throw new ArgumentNullException(nameof(company), "Company domain model cannot be null");

            var result = await _companyApplication.AddAsync(company);

            return result;
        }
    }
}