using System;
using System.Collections.Generic;

namespace MusicCaCaly.Models.Dtos
{
    public class AlbumDetailsDto
    {
        /// <summary>
        /// Id of the album
        /// </summary>
        /// <value>A number</value>
        public int Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// The published date of the album
        /// </summary>
        /// <value>Published date as date</value>
        public DateTime PublishedDate { get; set; }
        /// <summary>
        /// All artists for album, ordered by their Order mark
        /// </summary>
        /// <value>A list of artists</value>
        public IEnumerable<ArtistDto> ArtistsInOrder { get; set; }
        /// <summary>
        /// All songs associated with that particular album
        /// </summary>
        /// <value>A list of songs</value>
        public IEnumerable<SongDto> Songs { get; set; }
    }
}