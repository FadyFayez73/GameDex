using MediatR;
using Core.Dtos.Albums;
using System.Collections.Generic;

namespace Core.Features.Albums.Queries.Commands
{
    public class GetAllAlbumsCommand : IRequest<IEnumerable<AlbumDto>>
    {
    }
}