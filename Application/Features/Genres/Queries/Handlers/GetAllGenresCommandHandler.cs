using AutoMapper;
using Application.Dtos.Genres;
using Application.Features.Genres.Queries.Commands;
using Domain.Entities;
using MediatR;
using Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Genres.Queries.Handlers
{
    public class GetAllGenresCommandHandler : IRequestHandler<GetAllGenresCommand, IEnumerable<GenreDto>>
    {
        private readonly IGenreServices _genreServices;
        private readonly IMapper _mapper;

        public GetAllGenresCommandHandler(IGenreServices genreServices, IMapper mapper)
        {
            _genreServices = genreServices;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GenreDto>> Handle(GetAllGenresCommand request, CancellationToken cancellationToken)
        {
            var genres = await _genreServices.GetAllGenresAsync();
            var dto = _mapper.Map<IEnumerable<GenreDto>>(genres);
            return dto;
        }
    }
}
