using System.Collections.Generic;
using MusicCaCaly.Models.Dtos;
using MusicCaCaly.Repositories.Interfaces;
using MusicCaCaly.Services.Interfaces;

namespace MusicCaCaly.Services.Implementations
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbumService(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public AlbumDetailsDto GetAlbumById(int id)
        {
            return _albumRepository.GetAlbumById(id);
        }

        public IEnumerable<SongDto> GetSongsByAlbumId(int albumId)
        {
            return _albumRepository.GetSongsByAlbumId(albumId);
        }
    }
}