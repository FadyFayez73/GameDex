using MediatR;
using Domain.Entities;
using System.Collections.Generic;
using Application.Dtos.Platforms;

namespace Application.Features.Platforms.Queries.Commands
{
    public class GetAllPlatformsCommand : IRequest<IEnumerable<PlatformDto>>
    {
    }
}