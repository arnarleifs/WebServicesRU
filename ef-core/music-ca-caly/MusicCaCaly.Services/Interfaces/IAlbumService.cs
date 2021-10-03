using System.Collections.Generic;
using MusicCaCaly.Models.Dtos;

namespace MusicCaCaly.Services.Interfaces
{
    public interface IAlbumService
    {
        AlbumDetailsDto GetAlbumById(int id);
        IEnumerable<SongDto> GetSongsByAlbumId(int albumId);
    }
}