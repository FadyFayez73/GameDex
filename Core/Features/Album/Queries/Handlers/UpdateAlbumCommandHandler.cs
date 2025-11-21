using AutoMapper;
using Core.Features.Albums.Queries.Commands;
using Domain.Entities;
using MediatR;
using Services.Contracts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Features.Albums.Queries.Handlers
{
    public class UpdateAlbumCommandHandler : IRequestHandler<UpdateAlbumCommand, bool>
    {
        private readonly IAlbumServices _albumServices;
        private readonly IMapper _mapper;

        public UpdateAlbumCommandHandler(IAlbumServices albumServices, IMapper mapper)
        {
            _albumServices = albumServices;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateAlbumCommand request, CancellationToken cancellationToken)
        {
            var album = _mapper.Map<Album>(request);
            if (album == null) throw new ArgumentNullException(nameof(album));
            album.AlbumID = request.AlbumId;
            var result = await _albumServices.UpdateAsync(album);
            return result;
        }
    }
}