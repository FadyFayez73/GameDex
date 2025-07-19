using AutoMapper;
using Core.Features.Games.Queries.Commands;
using Core.Features.Medias.Queries.Commands;
using MediatR;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Medias.Queries.Handlers
{
    public class DeleteMediaCommandHandler : IRequestHandler<DeleteMediaCommand, bool>
    {
        private readonly IMediaServices _mediaServices;
        public DeleteMediaCommandHandler(IMediaServices mediaServices)
        {
            _mediaServices = mediaServices;
        }

        public async Task<bool> Handle(DeleteMediaCommand request, CancellationToken cancellationToken)
        {
            var result = await _mediaServices.DeleteAsync(request.GameID);
            return result;
        }
    }
}