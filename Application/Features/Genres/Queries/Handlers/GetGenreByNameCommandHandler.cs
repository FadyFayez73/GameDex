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
    public class GetGenreByNameCommandHandler : IRequestHandler<GetGenreByNameCommand, GenreDto>
    {
        private readonly IGenreApplication _genreApplication;
        private readonly IMapper _mapper;

        public GetGenreByNameCommandHandler(IGenreApplication genreApplication, IMapper mapper)
        {
            _genreApplication = genreApplication;
            _mapper = mapper;
        }

        public async Task<GenreDto> Handle(GetGenreByNameCommand request, CancellationToken cancellationToken)
        {
            var genre = await _genreApplication.GetGenreByNameAsync(request.Name);
            var dto = _mapper.Map<GenreDto>(genre);
            return dto;
        }
    }
}
