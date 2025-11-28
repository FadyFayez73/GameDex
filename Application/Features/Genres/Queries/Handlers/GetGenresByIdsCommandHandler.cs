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
    public class GetGenresByIdsCommandHandler : IRequestHandler<GetGenresByIdsCommand, IEnumerable<GenreDto>>
    {
        private readonly IGenreServices _genreServices;
        private readonly IMapper _mapper;
        public GetGenresByIdsCommandHandler(IGenreServices genreServices, IMapper mapper)
        {
            _genreServices = genreServices;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GenreDto>> Handle(GetGenresByIdsCommand request, CancellationToken cancellationToken)
        {
            var genres = await _genreServices.GetGenresByIdsAsync(request.GenreIds);
            var genresDto = _mapper.Map<IEnumerable<GenreDto>>(genres);

            return genresDto;
        }
    }
}
