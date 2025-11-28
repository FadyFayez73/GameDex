using AutoMapper;
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
    public class DeleteGameCommandHandler : IRequestHandler<DeleteGameCommand, bool>
    {
        private readonly IGameServices _gameServices;
        public DeleteGameCommandHandler(IGameServices gameServices)
        {
            _gameServices = gameServices;
        }

        public async Task<bool> Handle(DeleteGameCommand request, CancellationToken cancellationToken)
        {
            var result = await _gameServices.DeleteAsync(request.GameID);
            return result;
        }
    }
}
