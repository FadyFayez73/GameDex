using MediatR;
using System;

namespace Application.Features.Albums.Queries.Commands
{
    public class CreateAlbumCommand : IRequest<(bool, Guid)>
    {
        public string Name { get; set; } = string.Empty;
        public string Producer { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;
        public string Length { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string ReleaseDate { get; set; } = string.Empty;
        public Guid GameID { get; set; }
    }
}