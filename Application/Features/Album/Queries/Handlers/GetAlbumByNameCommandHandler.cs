using AutoMapper;
using Application.Dtos.Albums;
using Application.Features.Albums.Queries.Commands;
using MediatR;
using Application.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Albums.Queries.Handlers
{
    public class GetAlbumByNameCommandHandler : IRequestHandler<GetAlbumByNameCommand, AlbumDto?>
    {
        private readonly IAlbumServices _albumServices;
        private readonly IMapper _mapper;

        public GetAlbumByNameCommandHandler(IAlbumServices albumServices, IMapper mapper)
        {
            _albumServices = albumServices;
            _mapper = mapper;
        }

        public async Task<AlbumDto?> Handle(GetAlbumByNameCommand request, CancellationToken cancellationToken)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Name))
                throw new System.ArgumentException("Invalid album name.", nameof(request));

            var album = await _albumServices.GetAlbumByNameAsync(request.Name);
            return album == null ? null : _mapper.Map<AlbumDto>(album);
        }
    }
}