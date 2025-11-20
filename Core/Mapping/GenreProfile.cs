using AutoMapper;
using Core.Dtos.Genres;
using Core.Features.Genres.Queries.Commands;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping
{
    public class GenreProfile : Profile
    {
        public GenreProfile() 
        {
            CreateMap<CreateGenreCommand, Genre>();
            CreateMap<UpdateGenreCommand, Genre>();
            CreateMap<DeleteGenreCommand, Genre>();
            CreateMap<Genre, GenreDto>();
        }
    }
}
