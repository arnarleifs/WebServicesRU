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
    public class ReviewRepository : IReviewRepository
    {
        private readonly MusicDbContext _dbContext;

        public ReviewRepository(MusicDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int CreateNewReview(ReviewInputModel review)
        {
            var songToLink = _dbContext
                .Songs
                .Include(s => s.Reviews)
                .FirstOrDefault(s => s.Id == review.SongId);
            
            if (songToLink == null) { return -1; } // Could throw an exception here

            var entity = new Review
            {
                Title = review.Title,
                Text = review.Text,
                NumStars = review.NumStars
            };

            songToLink.Reviews.Add(entity);
            _dbContext.SaveChanges();

            return entity.Id;
        }

        public IEnumerable<AlbumReviewDto> GetAlbumsReviewsByArtistId(int artistId)
        {
            return _dbContext
                .Albums
                .Include(a => a.ArtistLink)
                .Include(a => a.Songs)
                .ThenInclude(a => a.Reviews)
                .Where(a => a.ArtistLink.Any(al => al.ArtistId == artistId))
                .Select(a => new AlbumReviewDto
                {
                    AlbumId = a.Id,
                    Reviews = a.Songs.Select(s =>
                        s.Reviews.Select(r => new ReviewDto
                        {
                            Id = r.Id,
                            Title = r.Title,
                            Text = r.Text,
                            NumStars = r.NumStars
                        })
                    ).SelectMany(r => r),
                    AverageRating = a.Songs
                        .Select(s => s.Reviews)
                        .SelectMany(r => r)
                        .Average(r => r.NumStars)
                }).ToList();
        }

        public IEnumerable<ReviewDto> GetReviewsByAlbumId(int albumId)
        {
            return _dbContext
                .Albums
                .Include(a => a.Songs)
                .ThenInclude(song => song.Reviews)
                .Where(a => a.Id == albumId)
                .Select(a => a.Songs
                    .Select(s => s.Reviews
                        .Select(r => new ReviewDto
                        {
                            Id = r.Id,
                            Title = r.Title,
                            Text = r.Text,
                            NumStars = r.NumStars
                        })
                    )
                    .SelectMany(r => r)
                )
                .SelectMany(r => r)
                .ToList();
        }
    }
}