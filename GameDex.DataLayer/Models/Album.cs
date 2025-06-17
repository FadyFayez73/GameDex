namespace GameDex.DataLayer.Models
{
    public class Album
    {
        // Property
        public int AlbumID { get; set; }
        public string Name { get; set; }
        public string Producer { get; set; }
        public string Language { get; set; }
        public string Length { get; set; }
        public string Genre { get; set; }
        public string ReleaseDate { get; set; }

        // Game Entity Relation Many to One
        public int? GameID { get; set; }
        public Game? Game { get; set; }

        // Song Entity Relation One to Many
        public ICollection<Song>? Songs { get; set;}
    }
}
