using MediatR;
using Domain.Entities;
using System;
using Core.Dtos.Platforms;

namespace Core.Features.Platforms.Queries.Commands
{
    public class GetPlatformByIdCommand : IRequest<PlatformDto?>
    {
        public Guid PlatformId { get; set; }

        public GetPlatformByIdCommand(Guid platformId)
        {
            PlatformId = platformId;
        }
    }
}