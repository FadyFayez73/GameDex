using AutoMapper;
using Core.Dtos.Games;
using Core.Dtos.Medias;
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
    public class GetMediaByIdCommandHandler : IRequestHandler<GetMediaByIdCommand, MediaDto>
    {
        private readonly IMediaServices _mediaServices;
        private readonly IMapper _mapper;
        public GetMediaByIdCommandHandler(IMediaServices mediaServices, IMapper mapper)
        {
            _mediaServices = mediaServices;
            _mapper = mapper;
        }

        public async Task<MediaDto> Handle(GetMediaByIdCommand request, CancellationToken cancellationToken)
        {
            var game = _mapper.Map<MediaDto>(await _mediaServices
                .GetMediaByIdAsync(request.Id));
            return game;
        }
    }
}