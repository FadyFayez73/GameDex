using AutoMapper;
using Application.Features.Games.Queries.Commands;
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
    public class UpdateMediaCommandHandler : IRequestHandler<UpdateMediaCommand, bool>
    {
        private readonly IMediaServices _medIaServices;
        private readonly IMapper _mapper;

        public UpdateMediaCommandHandler(IMediaServices medIaServices, IMapper mapper)
        {
            _medIaServices = medIaServices;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateMediaCommand request, CancellationToken cancellationToken)
        {
            var mediaDomainModel = _mapper.Map<Media>(request);

            if (mediaDomainModel == null)
                throw new ArgumentNullException(nameof(mediaDomainModel), "Cannot convert from \"UpdateMediaCommand\" to \"Media Domain Model\"!");

            var result = await _medIaServices.UpdateAsync(mediaDomainModel);
            return result;
        }
    }
}
