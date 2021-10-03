using System;
using System.Collections.Generic;

namespace MusicCaCaly.Repositories.Entities
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        // Navigation properties
        public ICollection<AlbumArtist> AlbumLink { get; set; }
    }
}