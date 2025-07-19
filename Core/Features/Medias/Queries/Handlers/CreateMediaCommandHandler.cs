using AutoMapper;
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
    public class CreateMediaCommandHandler : IRequestHandler<CreateMediaCommand, bool>
    {
        private readonly IMediaServices _mediaServices;
        private readonly IMapper _mapper;

        public CreateMediaCommandHandler(IMediaServices mediaServices, IMapper mapper)
        {
            _mediaServices = mediaServices;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateMediaCommand request, CancellationToken cancellationToken)
        {
            var mediaDomainModel = _mapper.Map<Media>(request);
            if(mediaDomainModel == null) throw new ArgumentNullException(nameof(mediaDomainModel), "Game domain model cannot be null");
            
            var result = await _mediaServices.AddAsync(mediaDomainModel);

            return result;
        }
    }
}
