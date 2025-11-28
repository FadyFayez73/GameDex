using AutoMapper;
using Application.Dtos.Genres;
using Application.Features.Genres.Queries.Commands;
using MediatR;
using Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Genres.Queries.Handlers
{
    public class GetGenresByNamesCommandHandler : IRequestHandler<GetGenresByNamesCommand, IEnumerable<GenreDto>>
    {
        private readonly IGenreApplication _genreApplication;
        private readonly IMapper _mapper;

        public GetGenresByNamesCommandHandler(IGenreApplication genreApplication, IMapper mapper)
        {
            _genreApplication = genreApplication;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GenreDto>> Handle(GetGenresByNamesCommand request, CancellationToken cancellationToken)
        {
            var genres = await _genreApplication.GetGenresByNamesAsync(request.GenreNames);
            var genresDto = _mapper.Map<IEnumerable<GenreDto>>(genres);

            return genresDto;
        }
    }
}
