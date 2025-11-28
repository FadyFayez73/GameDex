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
    public class GetAlbumsByProducerCommandHandler : IRequestHandler<GetAlbumsByProducerCommand, IEnumerable<AlbumDto>>
    {
        private readonly IAlbumApplication _albumApplication;
        private readonly IMapper _mapper;

        public GetAlbumsByProducerCommandHandler(IAlbumApplication albumApplication, IMapper mapper)
        {
            _albumApplication = albumApplication;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AlbumDto>> Handle(GetAlbumsByProducerCommand request, CancellationToken cancellationToken)
        {
            var albums = await _albumApplication.GetAlbumsByProducerAsync(request.Producer);
            return _mapper.Map<IEnumerable<AlbumDto>>(albums);
        }
    }
}