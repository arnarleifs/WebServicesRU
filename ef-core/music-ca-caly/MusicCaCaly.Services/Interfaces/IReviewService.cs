using System.Collections.Generic;
using MusicCaCaly.Models.Dtos;
using MusicCaCaly.Models.InputModels;

namespace MusicCaCaly.Services.Interfaces
{
    public interface IReviewService
    {
        IEnumerable<AlbumReviewDto> GetAlbumsReviewsByArtistId(int artistId);
        IEnumerable<ReviewDto> GetReviewsByAlbumId(int albumId);
        int CreateNewReview(ReviewInputModel review);
    }
}