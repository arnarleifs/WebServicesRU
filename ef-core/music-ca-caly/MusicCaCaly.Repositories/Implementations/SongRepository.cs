using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MusicCaCaly.Models.Dtos;
using MusicCaCaly.Models.InputModels;
using MusicCaCaly.Repositories.Contexts;
using MusicCaCaly.Repositories.Entities;
using MusicCaCaly.Repositories.Interfaces;

namespace MusicCaCaly.Repositories.Implementations
{
    public class SongRepository : ISongRepository
    {
        private readonly MusicDbContext _dbContext;

        public SongRepository(MusicDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int CreateNewSong(SongInputModel song)
        {
            var entity = new Song
            {
                Name = song.Name,
                Duration = song.Duration,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            _dbContext.Songs.Add(entity);
            _dbContext.SaveChanges();

            return entity.Id;
        }

        public SongDetailsDto GetSongById(int id)
        {
            return _dbContext
                .Songs
                .Include(s => s.Albums)
                .Include(s => s.Reviews)
                .Where(s => s.Id == id)
                .Select(s => new SongDetailsDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Duration = s.Duration,
                    Albums = s.Albums.Select(a => new AlbumDto
                    {
                        Id = a.Id,
                        Name = a.Name,
                        PublishedDate = a.PublishedDate
                    }),
                    Reviews = s.Reviews.Select(r => new ReviewDto
                    {
                        Id = r.Id,
                        Title = r.Title,
                        Text = r.Text,
                        NumStars = r.NumStars
                    }),
                    AverageRating = s.Reviews.Any() ? s.Reviews.Average(r => r.NumStars) : 0
                })
                .FirstOrDefault();
        }

        public void LinkSongToAlbum(int albumId, int songId)
        {
            throw new System.NotImplementedException();
        }
    }
}