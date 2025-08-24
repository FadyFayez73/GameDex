using AutoMapper;
using Core.Dtos.Genres;
using Core.Features.Genres.Queries.Commands;
using MediatR;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Genres.Queries.Handlers
{
    public class GetGenresByNamesCommandHandler : IRequestHandler<GetGenresByNamesCommand, IEnumerable<GenreDto>>
    {
        private readonly IGenreServices _genreServices;
        private readonly IMapper _mapper;

        public GetGenresByNamesCommandHandler(IGenreServices genreServices, IMapper mapper)
        {
            _genreServices = genreServices;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GenreDto>> Handle(GetGenresByNamesCommand request, CancellationToken cancellationToken)
        {
            var genres = await _genreServices.GetGenresByNamesAsync(request.GenreNames);
            var genresDto = _mapper.Map<IEnumerable<GenreDto>>(genres);

            return genresDto;
        }
    }
}
