using MediatR;
using Application.Dtos.Albums;
using System.Collections.Generic;

namespace Application.Features.Albums.Queries.Commands
{
    public class GetAllAlbumsCommand : IRequest<IEnumerable<AlbumDto>>
    {
    }
}