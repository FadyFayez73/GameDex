using AutoMapper;
using Application.Features.Games.Queries.Commands;
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
    public class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommand, bool>
    {
        private readonly IGenreApplication _genreApplication;

        public DeleteGenreCommandHandler(IGenreApplication genreApplication)
        {
            _genreApplication = genreApplication;
        }

        public async Task<bool> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
        {
            var result = await _genreApplication.DeleteAsync(request.Id);
            return result;
        }
    }
}
