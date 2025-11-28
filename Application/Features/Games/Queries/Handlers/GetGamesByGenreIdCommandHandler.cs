using AutoMapper;
using Application.Dtos.Games;
using Application.Features.Games.Queries.Commands;
using MediatR;
using Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Games.Queries.Handlers
{
    public class GetGamesByGenreIdCommandHandler : IRequestHandler<GetGamesByGenreIdCommand, IEnumerable<GameForDisplayDto>>
    {
        private readonly IMapper _mapper;
        private readonly IGameServices _gameServices;

        public GetGamesByGenreIdCommandHandler(IGameServices gameServices, IMapper mapper) 
        {
            _mapper = mapper;
            _gameServices = gameServices;
        }

        public async Task<IEnumerable<GameForDisplayDto>> Handle(GetGamesByGenreIdCommand request, CancellationToken cancellationToken)
        {
            var games = await _gameServices.GetGamesByGenreIdAsync(request.GenreID);
            var gamesDto = _mapper.Map<IEnumerable<GameForDisplayDto>>(games);

            return gamesDto;
        }
    }
}
