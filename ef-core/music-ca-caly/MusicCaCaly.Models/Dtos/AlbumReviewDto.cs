using System.Collections.Generic;

namespace MusicCaCaly.Models.Dtos
{
    public class AlbumReviewDto
    {
        public int AlbumId { get; set; }
        /// <summary>
        /// All reviews associated with that particular album
        /// </summary>
        /// <value>A list of reviews</value>
        public IEnumerable<ReviewDto> Reviews { get; set; }
        /// <summary>
        /// Average rating for that particular album, rounded to the nearest 0.1 point
        /// </summary>
        /// <value>Average rating (represented as double)</value>
        public double AverageRating { get; set; }
    }
}