using System.Collections.Generic;
using MusicCaCaly.Models.Dtos;

namespace MusicCaCaly.Repositories.Interfaces
{
    public interface IAlbumRepository
    {
        AlbumDetailsDto GetAlbumById(int id);
        IEnumerable<SongDto> GetSongsByAlbumId(int albumId);
    }
}