using System;
using System.Collections.Generic;

namespace MusicCaCaly.Repositories.Entities
{
    public class Song
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public ICollection<Album> Albums { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}