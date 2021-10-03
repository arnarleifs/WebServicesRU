using System;

namespace MusicCaCaly.Repositories.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int NumStars { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int SongId { get; set; }

        // Navigation properties
        public Song Song { get; set; }
    }
}