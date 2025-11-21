using System;

namespace Core.Dtos.Albums
{
    public struct SongDto
    {
        public Guid SongID { get; set; }
        public string Name { get; set; }
        public int DiscNumber { get; set; }
        public int TrackNumber { get; set; }
        public string Detail { get; set; }
        public Guid AlbumID { get; set; }
    }
}