using AutoMapper;
using Core.Dtos.Games;
using Core.Dtos.Medias;
using Core.Features.Medias.Queries.Commands;
using Domain.Entities;
using MediatR;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Medias.Queries.Handlers
{
    public class GetMediasByGameIdCommandHandler 
        : IRequestHandler<GetMediasByGameIdCommand, IEnumerable<MediaDto>>
    {
        private readonly IMediaServices _mediaServices;
        private readonly IMapper _mapper;

        public GetMediasByGameIdCommandHandler(IMediaServices mediaServices, IMapper mapper)
        {
            _mediaServices = mediaServices;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MediaDto>> Handle(GetMediasByGameIdCommand request, CancellationToken cancellationToken)
        {
            var medias = await _mediaServices.GetMediasByGameIdAsync(request.GameId);
            var mediasDto = _mapper.Map<IEnumerable<MediaDto>>(medias);

            return mediasDto;
        }
    }
}
