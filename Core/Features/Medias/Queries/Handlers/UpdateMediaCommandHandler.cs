using AutoMapper;
using Core.Features.Games.Queries.Commands;
using Core.Features.Medias.Queries.Commands;
using Domain.Entities;
using MediatR;
using Services.Contracts;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Medias.Queries.Handlers
{
    public class UpdateMediaCommandHandler : IRequestHandler<UpdateMediaCommand, bool>
    {
        private readonly IMediaServices _mediaServices;
        private readonly IMapper _mapper;

        public UpdateMediaCommandHandler(IMediaServices mediaServices, IMapper mapper)
        {
            _mediaServices = mediaServices;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateMediaCommand request, CancellationToken cancellationToken)
        {
            var mediaDomainModel = _mapper.Map<Media>(request);

            if (mediaDomainModel == null)
                throw new ArgumentNullException(nameof(mediaDomainModel), "Cannot convert from \"UpdateMediaCommand\" to \"Media Domain Model\"!");

            var result = await _mediaServices.UpdateAsync(mediaDomainModel);
            return result;
        }
    }
}
