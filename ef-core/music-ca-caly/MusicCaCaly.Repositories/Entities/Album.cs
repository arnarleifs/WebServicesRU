using System;
using System.Collections.Generic;

namespace MusicCaCaly.Repositories.Entities
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime PublishedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        // Navigation properties
        public ICollection<AlbumArtist> ArtistLink { get; set; }
        public ICollection<Song> Songs { get; set; }
    }
}