using Microsoft.AspNetCore.Mvc;
using MusicCaCaly.Models.InputModels;
using MusicCaCaly.Services.Interfaces;

namespace MusicCaCaly.WebApi.Controllers
{
    [ApiController]
    [Route("reviews")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost]
        [Route("")]
        public IActionResult CreateNewReview([FromBody] ReviewInputModel review)
        {
            _reviewService.CreateNewReview(review);
            return new StatusCodeResult(201);
        }
    }
}