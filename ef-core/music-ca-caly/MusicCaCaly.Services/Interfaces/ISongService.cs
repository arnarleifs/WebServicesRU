using MusicCaCaly.Models.Dtos;
using MusicCaCaly.Models.InputModels;

namespace MusicCaCaly.Services.Interfaces
{
    public interface ISongService
    {
        SongDetailsDto GetSongById(int id);
        int CreateNewSong(SongInputModel song);
        void LinkSongToAlbum(int albumId, int songId);
    }
}