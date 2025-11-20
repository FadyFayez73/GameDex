using AutoMapper;
using Core.Dtos.Companies;
using Core.Dtos.Games;
using Core.Features.Companies.Queries.Commands;
using Core.Features.Games.Queries.Commands;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile() 
        {
            CreateMap<Company, CompanyDto>().ReverseMap();
            CreateMap<CreateCompanyCommand, Company>();
            CreateMap<UpdateCompanyCommand, Company>();
        }
    }
}
