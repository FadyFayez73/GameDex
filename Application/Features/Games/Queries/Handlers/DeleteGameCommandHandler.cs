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
        private readonly IGameApplication _gameApplication;
        public DeleteGameCommandHandler(IGameApplication gameApplication)
        {
            _gameApplication = gameApplication;
        }

        public async Task<bool> Handle(DeleteGameCommand request, CancellationToken cancellationToken)
        {
            var result = await _gameApplication.DeleteAsync(request.GameID);
            return result;
        }
    }
}
