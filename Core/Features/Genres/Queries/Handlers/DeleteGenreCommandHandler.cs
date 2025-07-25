using AutoMapper;
using Core.Features.Games.Queries.Commands;
using MediatR;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Genres.Queries.Handlers
{
    public class DeleteGenreCommandHandler : IRequestHandler<DeleteGameCommand, bool>
    {
        private readonly IGenreServices _genreServices;

        public DeleteGenreCommandHandler(IGenreServices genreServices)
        {
            _genreServices = genreServices;
        }

        public async Task<bool> Handle(DeleteGameCommand request, CancellationToken cancellationToken)
        {
            var result = await _genreServices.DeleteAsync(request.GameID);
            return result;
        }
    }
}
