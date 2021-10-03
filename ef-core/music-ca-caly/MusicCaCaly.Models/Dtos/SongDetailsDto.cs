using System;
using System.Collections.Generic;

namespace MusicCaCaly.Models.Dtos
{
    public class SongDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        /// <summary>
        /// All albums this song appears on
        /// </summary>
        /// <value>A list of albums</value>
        public IEnumerable<AlbumDto> Albums { get; set; }
        /// <summary>
        /// All reviews this song has received
        /// </summary>
        /// <value>A list of reviews</value>
        public IEnumerable<ReviewDto> Reviews { get; set; }
        /// <summary>
        /// Average rating for that particular song, rounded to the nearest 0.1 point
        /// </summary>
        /// <value>Average rating (represented as double)</value>
        public double AverageRating { get; set; }
    }
}