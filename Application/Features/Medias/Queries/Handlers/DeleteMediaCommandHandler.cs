using AutoMapper;
using Application.Features.Games.Queries.Commands;
using Application.Features.Medias.Queries.Commands;
using MediatR;
using Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Medias.Queries.Handlers
{
    public class DeleteMediaCommandHandler : IRequestHandler<DeleteMediaCommand, bool>
    {
        private readonly IMediaServices _medIaServices;
        public DeleteMediaCommandHandler(IMediaServices medIaServices)
        {
            _medIaServices = medIaServices;
        }

        public async Task<bool> Handle(DeleteMediaCommand request, CancellationToken cancellationToken)
        {
            var result = await _medIaServices.DeleteAsync(request.GameID);
            return result;
        }
    }
}