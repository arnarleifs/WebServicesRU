using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MusicCaCaly.Models.Dtos;
using MusicCaCaly.Models.InputModels;
using MusicCaCaly.Repositories.Contexts;
using MusicCaCaly.Repositories.Entities;
using MusicCaCaly.Repositories.Interfaces;

namespace MusicCaCaly.Repositories.Implementations
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly MusicDbContext _dbContext;

        public ArtistRepository(MusicDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int CreateNewArtist(ArtistInputModel artist)
        {
            var entity = new Artist
            {
                Name = artist.Name,
                Bio = artist.Bio,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            _dbContext.Artists.Add(entity);
            // COMMIT
            _dbContext.SaveChanges();

            return entity.Id;
        }

        public void DeleteArtist(int id)
        {
            var entity = _dbContext.Artists.FirstOrDefault(a => a.Id == id);
            if (entity == null) { return; }

            _dbContext.Artists.Remove(entity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<AlbumDto> GetAlbumsByArtistId(int artistId)
        {
            return _dbContext
                .Artists
                .Include(a => a.AlbumLink)
                .ThenInclude(al => al.Album)
                .Where(a => a.Id == artistId)
                .Select(a => a.AlbumLink.Select(al => new AlbumDto
                {
                    Id = al.Album.Id,
                    Name = al.Album.Name,
                    PublishedDate = al.Album.PublishedDate
                }))
                .FirstOrDefault();
        }

        public IEnumerable<ArtistDto> GetAllArtists()
        {
            return _dbContext.Artists.Select(a => new ArtistDto
            {
                Id = a.Id,
                Name = a.Name,
                Bio = a.Bio
            }).ToList();
        }

        public ArtistDetailsDto GetArtistById(int id)
        {
            return _dbContext
                .Artists
                .Include(a => a.AlbumLink)
                .ThenInclude(al => al.Album)
                .Where(a => a.Id == id)
                .Select(a => new ArtistDetailsDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    Bio = a.Bio,
                    Albums = a.AlbumLink.Select(al => new AlbumDto
                    {
                        Id = al.Album.Id,
                        Name = al.Album.Name,
                        PublishedDate = al.Album.PublishedDate
                    })
                }).FirstOrDefault();
        }

        public IEnumerable<SongDto> GetSongsByArtistId(int artistId)
        {
            return _dbContext
                .Artists
                .Include(a => a.AlbumLink)
                .ThenInclude(al => al.Album)
                .ThenInclude(album => album.Songs)
                .Where(a => a.Id == artistId)
                // IEnumerable<IEnumerable<SongDto>>
                .Select(a => a.AlbumLink
                    // IEnumerable<IEnumerable<SongDto>>
                    .Select(al => al.Album.Songs
                        // IEnumerable<SongDto>
                        .Select(s => new SongDto
                        {
                            Id = s.Id,
                            Name = s.Name,
                            Duration = s.Duration
                        })
                    ).SelectMany(s => s)
                ).SelectMany(s => s)
            .ToList();
        }

        public void UpdateArtist(int id, ArtistInputModel artist)
        {
            var entity = _dbContext.Artists.FirstOrDefault(a => a.Id == id);
            if (entity == null) { return; }

            // Update properties
            entity.Name = artist.Name;
            entity.Bio = artist.Bio;
            entity.ModifiedDate = DateTime.Now;

            _dbContext.SaveChanges();
        }
    }
}