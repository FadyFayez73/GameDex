using MediatR;
using Domain.Entities;
using System.Collections.Generic;
using Core.Dtos.Platforms;

namespace Core.Features.Platforms.Queries.Commands
{
    public class GetAllPlatformsCommand : IRequest<IEnumerable<PlatformDto>>
    {
    }
}