using AutoMapper;
using Application.Dtos.Platforms;
using Application.Features.Platforms.Queries.Commands;
using Domain.Entities;
using MediatR;
using Application.Contracts;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Platforms.Queries.Handlers
{
    public class GetAllPlatformsCommandHandler : IRequestHandler<GetAllPlatformsCommand, IEnumerable<PlatformDto>>
    {
        private readonly IPlatformServices _platformServices;
        private readonly IMapper _mapper;

        public GetAllPlatformsCommandHandler(IPlatformServices platformServices, IMapper mapper)
        {
            _platformServices = platformServices;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PlatformDto>> Handle(GetAllPlatformsCommand request, CancellationToken cancellationToken)
        {
            var platforms = await _platformServices.GetAllPlatformsAsync();
            var dtos = _mapper.Map<IEnumerable<PlatformDto>>(platforms);
            return dtos;
        }
    }
}