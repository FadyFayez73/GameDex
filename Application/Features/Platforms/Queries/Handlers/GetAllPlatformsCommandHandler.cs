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
        private readonly IPlatformApplication _platformApplication;
        private readonly IMapper _mapper;

        public GetAllPlatformsCommandHandler(IPlatformApplication platformApplication, IMapper mapper)
        {
            _platformApplication = platformApplication;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PlatformDto>> Handle(GetAllPlatformsCommand request, CancellationToken cancellationToken)
        {
            var platforms = await _platformApplication.GetAllPlatformsAsync();
            var dtos = _mapper.Map<IEnumerable<PlatformDto>>(platforms);
            return dtos;
        }
    }
}