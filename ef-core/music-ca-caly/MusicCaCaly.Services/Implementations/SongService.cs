using MusicCaCaly.Models.Dtos;
using MusicCaCaly.Models.InputModels;
using MusicCaCaly.Repositories.Interfaces;
using MusicCaCaly.Services.Interfaces;

namespace MusicCaCaly.Services.Implementations
{
    public class SongService : ISongService
    {
        private readonly ISongRepository _songRepository;

        public SongService(ISongRepository songRepository)
        {
            _songRepository = songRepository;
        }

        public int CreateNewSong(SongInputModel song)
        {
            return _songRepository.CreateNewSong(song);
        }

        public SongDetailsDto GetSongById(int id)
        {
            return _songRepository.GetSongById(id);
        }

        public void LinkSongToAlbum(int albumId, int songId)
        {
            _songRepository.LinkSongToAlbum(albumId, songId);
        }
    }
}