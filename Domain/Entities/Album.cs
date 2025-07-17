namespace Domain.Entities
{
    public class Album
    {
        // Property
        public Guid AlbumID { get; set; }
        public string Name { get; set; }
        public string Producer { get; set; }
        public string Language { get; set; }
        public string Length { get; set; }
        public string Genre { get; set; }
        public string ReleaseDate { get; set; }

        // Game Entity Relation Many to One
        public Guid GameID { get; set; }
        public Game? Game { get; set; }

        // Song Entity Relation One to Many
        public ICollection<Song>? Songs { get; set;}
    }
}
