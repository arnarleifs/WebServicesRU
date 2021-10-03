namespace MusicCaCaly.Models.InputModels
{
    public class ReviewInputModel
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public int NumStars { get; set; }
        public int SongId { get; set; }
    }
}