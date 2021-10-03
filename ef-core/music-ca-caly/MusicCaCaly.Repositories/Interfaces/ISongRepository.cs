using MusicCaCaly.Models.Dtos;
using MusicCaCaly.Models.InputModels;

namespace MusicCaCaly.Repositories.Interfaces
{
    public interface ISongRepository
    {
        SongDetailsDto GetSongById(int id);
        int CreateNewSong(SongInputModel song);
        void LinkSongToAlbum(int albumId, int songId);
    }
}