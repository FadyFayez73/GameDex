using MediatR;
using System;

namespace Core.Features.Platforms.Queries.Commands
{
    public class DeletePlatformCommand : IRequest<bool>
    {
        public Guid PlatformId { get; set; }
    }
}