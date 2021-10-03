namespace MusicCaCaly.Repositories.Entities
{
    public class AlbumArtist
    {
        public int ArtistId { get; set; }
        public int AlbumId { get; set; }
        public int Order { get; set; }

        // Navigation properties
        public Artist Artist { get; set; }
        public Album Album { get; set; } 
    }
}