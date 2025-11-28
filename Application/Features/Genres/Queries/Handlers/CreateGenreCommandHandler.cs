using AutoMapper;
using Application.Features.Genres.Queries.Commands;
using Domain.Entities;
using MediatR;
using Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Genres.Queries.Handlers
{
    public class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand, (bool, Guid)>
    {
        private readonly IGenreApplication _genreApplication;
        private readonly IMapper _mapper;

        public CreateGenreCommandHandler(IGenreApplication genreApplication, IMapper mapper)
        {
            _genreApplication = genreApplication;
            _mapper = mapper;
        }

        public async Task<(bool, Guid)> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
        {
            var genreDomain = _mapper.Map<Genre>(request);

            var result = await _genreApplication.AddAsync(genreDomain);
            return result;
        }
    }
}