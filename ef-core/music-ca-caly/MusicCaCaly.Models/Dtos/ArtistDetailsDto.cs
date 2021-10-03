using System.Collections.Generic;

namespace MusicCaCaly.Models.Dtos
{
    public class ArtistDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        /// <summary>
        /// Albums associated with artist
        /// </summary>
        /// <value>A list of albums</value>
        public IEnumerable<AlbumDto> Albums { get; set; }
    }
}