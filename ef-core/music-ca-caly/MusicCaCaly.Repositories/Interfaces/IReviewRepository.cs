using System.Collections.Generic;
using MusicCaCaly.Models.Dtos;
using MusicCaCaly.Models.InputModels;

namespace MusicCaCaly.Repositories.Interfaces
{
    public interface IReviewRepository
    {
        IEnumerable<ReviewDto> GetReviewsByAlbumId(int albumId);
        IEnumerable<AlbumReviewDto> GetAlbumsReviewsByArtistId(int artistId);
        int CreateNewReview(ReviewInputModel review);
    }
}