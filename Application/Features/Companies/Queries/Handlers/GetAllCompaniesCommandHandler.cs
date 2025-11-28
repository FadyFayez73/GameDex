using AutoMapper;
using Application.Dtos.Companies;
using Application.Features.Companies.Queries.Commands;
using Domain.Entities;
using MediatR;
using Application.Contracts;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Companies.Queries.Handlers
{
    public class GetAllCompaniesCommandHandler : IRequestHandler<GetAllCompaniesCommand, IEnumerable<CompanyDto>>
    {
        private readonly ICompanyApplication _companyApplication;
        private readonly IMapper _mapper;

        public GetAllCompaniesCommandHandler(ICompanyApplication companyApplication, IMapper mapper)
        {
            _companyApplication = companyApplication;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CompanyDto>> Handle(GetAllCompaniesCommand request, CancellationToken cancellationToken)
        {
            var companies = await _companyApplication.GetAllCompaniesAsync();
            var companyDtos = _mapper.Map<IEnumerable<CompanyDto>>(companies);
            return companyDtos;
        }
    }
}