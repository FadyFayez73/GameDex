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
    public class GetGenreByNameCommandHandler : IRequestHandler<GetGenreByNameCommand, GenreDto>
    {
        private readonly IGenreServices _genreServices;
        private readonly IMapper _mapper;

        public GetGenreByNameCommandHandler(IGenreServices genreServices, IMapper mapper)
        {
            _genreServices = genreServices;
            _mapper = mapper;
        }

        public async Task<GenreDto> Handle(GetGenreByNameCommand request, CancellationToken cancellationToken)
        {
            var genre = await _genreServices.GetGenreByNameAsync(request.Name);
            var dto = _mapper.Map<GenreDto>(genre);
            return dto;
        }
    }
}
