using AutoMapper;
using Application.Dtos.Games;
using Application.Dtos.Medias;
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
    public class GetMediaByIdCommandHandler : IRequestHandler<GetMediaByIdCommand, MediaDto?>
    {
        private readonly IMediaApplication _mediaApplication;
        private readonly IMapper _mapper;
        public GetMediaByIdCommandHandler(IMediaApplication mediaApplication, IMapper mapper)
        {
            _mediaApplication = mediaApplication;
            _mapper = mapper;
        }

        public async Task<MediaDto?> Handle(GetMediaByIdCommand request, CancellationToken cancellationToken)
        {
            var game = _mapper.Map<MediaDto>(await _mediaApplication
                .GetMediaByIdAsync(request.Id));
            return game;
        }
    }
}