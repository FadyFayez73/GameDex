using AutoMapper;
using Application.Dtos.Companies;
using Application.Dtos.Games;
using Application.Features.Companies.Queries.Commands;
using Application.Features.Games.Queries.Commands;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
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
