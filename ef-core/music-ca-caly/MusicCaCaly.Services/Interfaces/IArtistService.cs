using System.Collections.Generic;
using MusicCaCaly.Models.Dtos;
using MusicCaCaly.Models.InputModels;

namespace MusicCaCaly.Services.Interfaces
{
    public interface IArtistService
    {
        IEnumerable<ArtistDto> GetAllArtists();
        ArtistDetailsDto GetArtistById(int id);
        IEnumerable<AlbumDto> GetAlbumsByArtistId(int artistId);
        IEnumerable<SongDto> GetSongsByArtistId(int artistId);
        int CreateNewArtist(ArtistInputModel artist);
        void UpdateArtist(int id, ArtistInputModel artist);
        void DeleteArtist(int id);
    }
}