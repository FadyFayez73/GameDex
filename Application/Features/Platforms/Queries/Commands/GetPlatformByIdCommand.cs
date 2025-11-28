using MediatR;
using Domain.Entities;
using System;
using Application.Dtos.Platforms;

namespace Application.Features.Platforms.Queries.Commands
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