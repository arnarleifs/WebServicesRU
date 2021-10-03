namespace MusicCaCaly.Models.Dtos
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int NumStars { get; set; }
        public SongDto Song { get; set; }
    }
}