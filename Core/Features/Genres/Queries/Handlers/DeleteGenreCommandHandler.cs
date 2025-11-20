using AutoMapper;
using Core.Features.Games.Queries.Commands;
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
    public class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommand, bool>
    {
        private readonly IGenreServices _genreServices;

        public DeleteGenreCommandHandler(IGenreServices genreServices)
        {
            _genreServices = genreServices;
        }

        public async Task<bool> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
        {
            var result = await _genreServices.DeleteAsync(request.Id);
            return result;
        }
    }
}
