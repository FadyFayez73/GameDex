using AutoMapper;
using Core.Dtos.Albums;
using Core.Features.Albums.Queries.Commands;
using MediatR;
using Services.Contracts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Features.Albums.Queries.Handlers
{
    public class GetAlbumByIdCommandHandler : IRequestHandler<GetAlbumByIdCommand, AlbumDto?>
    {
        private readonly IAlbumServices _albumServices;
        private readonly IMapper _mapper;

        public GetAlbumByIdCommandHandler(IAlbumServices albumServices, IMapper mapper)
        {
            _albumServices = albumServices;
            _mapper = mapper;
        }

        public async Task<AlbumDto?> Handle(GetAlbumByIdCommand request, CancellationToken cancellationToken)
        {
            if (request == null || request.AlbumId == Guid.Empty)
                throw new ArgumentException("Invalid album id.", nameof(request));

            var album = await _albumServices.GetAlbumByIdAsync(request.AlbumId);
            return album == null ? null : _mapper.Map<AlbumDto>(album);
        }
    }
}