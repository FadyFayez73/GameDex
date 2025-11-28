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
    public class GetGenreByIdCommandHandler : IRequestHandler<GetGenreByIdCommand, GenreDto?>
    {
        private readonly IGenreServices _genreServices;
        private readonly IMapper _mapper;

        public GetGenreByIdCommandHandler(IGenreServices genreServices, IMapper mapper)
        {
            _genreServices = genreServices;
            _mapper = mapper;
        }

        public async Task<GenreDto?> Handle(GetGenreByIdCommand request, CancellationToken cancellationToken)
        {
            var genre = await _genreServices.GetGenreByIdAsync(request.GenreID);
            var dto = _mapper.Map<GenreDto>(genre);
            return dto;
        }
    }
}
