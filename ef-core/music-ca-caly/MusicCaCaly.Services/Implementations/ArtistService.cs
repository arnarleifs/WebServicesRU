using System.Collections.Generic;
using MusicCaCaly.Models.Dtos;
using MusicCaCaly.Models.InputModels;
using MusicCaCaly.Repositories.Interfaces;
using MusicCaCaly.Services.Interfaces;

namespace MusicCaCaly.Services.Implementations
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _artistRepository;

        public ArtistService(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public IEnumerable<AlbumDto> GetAlbumsByArtistId(int artistId)
        {
            return _artistRepository.GetAlbumsByArtistId(artistId);
        }

        public IEnumerable<ArtistDto> GetAllArtists()
        {
            return _artistRepository.GetAllArtists();
        }

        public ArtistDetailsDto GetArtistById(int id)
        {
            return _artistRepository.GetArtistById(id);
        }

        public IEnumerable<SongDto> GetSongsByArtistId(int artistId)
        {
            return _artistRepository.GetSongsByArtistId(artistId);
        }
        
        public int CreateNewArtist(ArtistInputModel artist)
        {
            return _artistRepository.CreateNewArtist(artist);
        }

        public void UpdateArtist(int id, ArtistInputModel artist)
        {
            _artistRepository.UpdateArtist(id, artist);
        }

        public void DeleteArtist(int id)
        {
            _artistRepository.DeleteArtist(id);
        }
    }
}