using AutoMapper;
using Core.Dtos.Companies;
using Core.Features.Companies.Queries.Commands;
using Domain.Entities;
using MediatR;
using Services.Contracts;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Features.Companies.Queries.Handlers
{
    public class GetAllCompaniesCommandHandler : IRequestHandler<GetAllCompaniesCommand, IEnumerable<CompanyDto>>
    {
        private readonly ICompanyServices _companyServices;
        private readonly IMapper _mapper;

        public GetAllCompaniesCommandHandler(ICompanyServices companyServices, IMapper mapper)
        {
            _companyServices = companyServices;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CompanyDto>> Handle(GetAllCompaniesCommand request, CancellationToken cancellationToken)
        {
            var companies = await _companyServices.GetAllCompaniesAsync();
            var companyDtos = _mapper.Map<IEnumerable<CompanyDto>>(companies);
            return companyDtos;
        }
    }
}