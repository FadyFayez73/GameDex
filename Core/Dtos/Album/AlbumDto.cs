using System;
using System.Collections.Generic;

namespace Core.Dtos.Albums
{
    public struct AlbumDto
    {
        public Guid AlbumID { get; set; }
        public string Name { get; set; } 
        public string Producer { get; set; }
        public string Language { get; set; }
        public string Length { get; set; }
        public string Genre { get; set; }
        public string ReleaseDate { get; set; }
        public Guid GameID { get; set; }
        public IEnumerable<SongDto>? Songs { get; set; }
    }
}