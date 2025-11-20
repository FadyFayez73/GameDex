using AutoMapper;
using Core.Features.Genres.Queries.Commands;
using Domain.Entities;
using MediatR;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Genres.Queries.Handlers
{
    public class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand, (bool, Guid)>
    {
        private readonly IGenreServices _genreServices;
        private readonly IMapper _mapper;

        public CreateGenreCommandHandler(IGenreServices genreServices, IMapper mapper)
        {
            _genreServices = genreServices;
            _mapper = mapper;
        }

        public async Task<(bool, Guid)> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
        {
            var genreDomain = _mapper.Map<Genre>(request);

            var result = await _genreServices.AddAsync(genreDomain);
            return result;
        }
    }
}