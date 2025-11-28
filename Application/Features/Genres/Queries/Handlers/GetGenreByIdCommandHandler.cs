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
        private readonly IGenreApplication _genreApplication;
        private readonly IMapper _mapper;

        public GetGenreByIdCommandHandler(IGenreApplication genreApplication, IMapper mapper)
        {
            _genreApplication = genreApplication;
            _mapper = mapper;
        }

        public async Task<GenreDto?> Handle(GetGenreByIdCommand request, CancellationToken cancellationToken)
        {
            var genre = await _genreApplication.GetGenreByIdAsync(request.GenreID);
            var dto = _mapper.Map<GenreDto>(genre);
            return dto;
        }
    }
}
