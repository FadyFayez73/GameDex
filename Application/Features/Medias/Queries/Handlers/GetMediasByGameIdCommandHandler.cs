using AutoMapper;
using Application.Dtos.Games;
using Application.Dtos.Medias;
using Application.Features.Medias.Queries.Commands;
using Domain.Entities;
using MediatR;
using Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Medias.Queries.Handlers
{
    public class GetMediasByGameIdCommandHandler 
        : IRequestHandler<GetMediasByGameIdCommand, IEnumerable<MediaDto>>
    {
        private readonly IMediaApplication _mediaApplication;
        private readonly IMapper _mapper;

        public GetMediasByGameIdCommandHandler(IMediaApplication mediaApplication, IMapper mapper)
        {
            _mediaApplication = mediaApplication;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MediaDto>> Handle(GetMediasByGameIdCommand request, CancellationToken cancellationToken)
        {
            var medias = await _mediaApplication.GetMediasByGameIdAsync(request.GameId);
            var mediasDto = _mapper.Map<IEnumerable<MediaDto>>(medias);

            return mediasDto;
        }
    }
}
