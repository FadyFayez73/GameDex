using AutoMapper;
using Application.Features.Albums.Queries.Commands;
using Domain.Entities;
using MediatR;
using Application.Contracts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Albums.Queries.Handlers
{
    public class CreateAlbumCommandHandler : IRequestHandler<CreateAlbumCommand, (bool, Guid)>
    {
        private readonly IAlbumApplication _albumApplication;
        private readonly IMapper _mapper;

        public CreateAlbumCommandHandler(IAlbumApplication albumApplication, IMapper mapper)
        {
            _albumApplication = albumApplication;
            _mapper = mapper;
        }

        public async Task<(bool, Guid)> Handle(CreateAlbumCommand request, CancellationToken cancellationToken)
        {
            var album = _mapper.Map<Album>(request);
            if (album == null) throw new ArgumentNullException(nameof(album));

            var result = await _albumApplication.AddAsync(album);
            return result;
        }
    }
}