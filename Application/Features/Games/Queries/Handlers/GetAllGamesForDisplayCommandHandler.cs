using AutoMapper;
using Application.Dtos.Games;
using Application.Features.Games.Queries.Commands;
using Domain.Entities;
using MediatR;
using Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Games.Queries.Handlers
{
    public class GetAllGamesForDisplayCommandHandler 
        : IRequestHandler<GetAllGamesForDisplayCommand, IEnumerable<GameForDisplayDto>>
    {
        private readonly IGameApplication _gameApplication;
        private readonly IMapper _mapper;
        public GetAllGamesForDisplayCommandHandler(IGameApplication gameApplication, IMapper mapper)
        {
            _gameApplication = gameApplication;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GameForDisplayDto>> Handle(GetAllGamesForDisplayCommand request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<GameForDisplayDto>>(await _gameApplication
                .GetAllGamesForDisplayAsync());
        }
    }
}
