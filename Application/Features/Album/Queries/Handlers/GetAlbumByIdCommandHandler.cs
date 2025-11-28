using AutoMapper;
using Application.Dtos.Albums;
using Application.Features.Albums.Queries.Commands;
using MediatR;
using Application.Contracts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Albums.Queries.Handlers
{
    public class GetAlbumByIdCommandHandler : IRequestHandler<GetAlbumByIdCommand, AlbumDto?>
    {
        private readonly IAlbumApplication _albumApplication;
        private readonly IMapper _mapper;

        public GetAlbumByIdCommandHandler(IAlbumApplication albumApplication, IMapper mapper)
        {
            _albumApplication = albumApplication;
            _mapper = mapper;
        }

        public async Task<AlbumDto?> Handle(GetAlbumByIdCommand request, CancellationToken cancellationToken)
        {
            if (request == null || request.AlbumId == Guid.Empty)
                throw new ArgumentException("Invalid album id.", nameof(request));

            var album = await _albumApplication.GetAlbumByIdAsync(request.AlbumId);
            return album == null ? null : _mapper.Map<AlbumDto>(album);
        }
    }
}