using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MusicCaCaly.Models.Dtos;
using MusicCaCaly.Repositories.Contexts;
using MusicCaCaly.Repositories.Interfaces;

namespace MusicCaCaly.Repositories.Implementations
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly MusicDbContext _dbContext;

        public AlbumRepository(MusicDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public AlbumDetailsDto GetAlbumById(int id)
        {
            return _dbContext
                .Albums
                .Include(a => a.ArtistLink)
                    .ThenInclude(al => al.Artist)
                .Include(a => a.Songs)
                .Where(a => a.Id == id)
                .Select(a => new AlbumDetailsDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    PublishedDate = a.PublishedDate,
                    ArtistsInOrder = a.ArtistLink.OrderBy(al => al.Order).Select(a => a.Artist).Select(a => new ArtistDto
                    {
                        Id = a.Id,
                        Name = a.Name,
                        Bio = a.Bio
                    }),
                    Songs = a.Songs.Select(s => new SongDto
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Duration = s.Duration
                    })
                }).FirstOrDefault();
        }

        public IEnumerable<SongDto> GetSongsByAlbumId(int albumId)
        {
            return _dbContext
                .Albums
                .Include(a => a.Songs)
                .Where(a => a.Id == albumId)
                .Select(a => a.Songs.Select(s => new SongDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Duration = s.Duration
                })).FirstOrDefault();
        }
    }
}