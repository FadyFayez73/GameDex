using AutoMapper;
using Application.Features.Medias.Queries.Commands;
using Domain.Entities;
using MediatR;
using Application.Contracts;
using Application.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Medias.Queries.Handlers
{
    public class CreateMediaCommandHandler : IRequestHandler<CreateMediaCommand, (bool, Guid)>
    {
        private readonly IMediaApplication _mediaApplication;
        private readonly IMapper _mapper;

        public CreateMediaCommandHandler(IMediaApplication mediaApplication, IMapper mapper)
        {
            _mediaApplication = mediaApplication;
            _mapper = mapper;
        }

        public async Task<(bool, Guid)> Handle(CreateMediaCommand request, CancellationToken cancellationToken)
        {
            var mediaDomainModel = _mapper.Map<Media>(request);
            if(mediaDomainModel == null) throw new ArgumentNullException(nameof(mediaDomainModel), "Media domain model cannot be null");
            
            var result = await _mediaApplication.AddAsync(mediaDomainModel);

            return result;
        }
    }
}
