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
    public class GetAlbumsByGenreCommandHandler : IRequestHandler<GetAlbumsByGenreCommand, IEnumerable<AlbumDto>>
    {
        private readonly IAlbumApplication _albumApplication;
        private readonly IMapper _mapper;

        public GetAlbumsByGenreCommandHandler(IAlbumApplication albumApplication, IMapper mapper)
        {
            _albumApplication = albumApplication;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AlbumDto>> Handle(GetAlbumsByGenreCommand request, CancellationToken cancellationToken)
        {
            var albums = await _albumApplication.GetAlbumsByGenreAsync(request.Genre);
            return _mapper.Map<IEnumerable<AlbumDto>>(albums);
        }
    }
}