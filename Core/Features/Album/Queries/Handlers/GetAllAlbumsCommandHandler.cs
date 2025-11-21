using AutoMapper;
using Core.Dtos.Albums;
using Core.Features.Albums.Queries.Commands;
using MediatR;
using Services.Contracts;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Features.Albums.Queries.Handlers
{
    public class GetAllAlbumsCommandHandler : IRequestHandler<GetAllAlbumsCommand, IEnumerable<AlbumDto>>
    {
        private readonly IAlbumServices _albumServices;
        private readonly IMapper _mapper;

        public GetAllAlbumsCommandHandler(IAlbumServices albumServices, IMapper mapper)
        {
            _albumServices = albumServices;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AlbumDto>> Handle(GetAllAlbumsCommand request, CancellationToken cancellationToken)
        {
            var albums = await _albumServices.GetAllAlbumsAsync();
            return _mapper.Map<IEnumerable<AlbumDto>>(albums);
        }
    }
}