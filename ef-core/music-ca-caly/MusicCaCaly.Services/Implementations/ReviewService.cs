using System.Collections.Generic;
using MusicCaCaly.Models.Dtos;
using MusicCaCaly.Models.InputModels;
using MusicCaCaly.Repositories.Interfaces;
using MusicCaCaly.Services.Interfaces;

namespace MusicCaCaly.Services.Implementations
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public int CreateNewReview(ReviewInputModel review)
        {
            return _reviewRepository.CreateNewReview(review);
        }

        public IEnumerable<AlbumReviewDto> GetAlbumsReviewsByArtistId(int artistId)
        {
            return _reviewRepository.GetAlbumsReviewsByArtistId(artistId);
        }

        public IEnumerable<ReviewDto> GetReviewsByAlbumId(int albumId)
        {
            return _reviewRepository.GetReviewsByAlbumId(albumId);
        }
    }
}