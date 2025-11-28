using AutoMapper;
using Application.Dtos.Albums;
using Application.Features.Albums.Queries.Commands;
using MediatR;
using Application.Contracts;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Albums.Queries.Handlers
{
    public class GetAlbumsByGameIdCommandHandler : IRequestHandler<GetAlbumsByGameIdCommand, IEnumerable<AlbumDto>>
    {
        private readonly IAlbumServices _albumServices;
        private readonly IMapper _mapper;

        public GetAlbumsByGameIdCommandHandler(IAlbumServices albumServices, IMapper mapper)
        {
            _albumServices = albumServices;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AlbumDto>> Handle(GetAlbumsByGameIdCommand request, CancellationToken cancellationToken)
        {
            var albums = await _albumServices.GetAlbumsByGameIdAsync(request.GameId);
            return _mapper.Map<IEnumerable<AlbumDto>>(albums);
        }
    }
}