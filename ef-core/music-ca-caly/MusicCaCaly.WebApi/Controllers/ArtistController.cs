using Microsoft.AspNetCore.Mvc;
using MusicCaCaly.Models.InputModels;
using MusicCaCaly.Services.Interfaces;

namespace MusicCaCaly.WebApi.Controllers
{
    [ApiController]
    [Route("artists")]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService _artistService;
        private readonly IReviewService _reviewService;

        public ArtistController(IArtistService artistService, IReviewService reviewService)
        {
            _artistService = artistService;
            _reviewService = reviewService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAllArtists()
        {
            return Ok(_artistService.GetAllArtists());
        }

        [HttpGet]
        [Route("{id}", Name = "GetArtistById")]
        public IActionResult GetArtistById(int id)
        {
            return Ok(_artistService.GetArtistById(id));
        }

        [HttpGet]
        [Route("{id}/albums")]
        public IActionResult GetAlbumsByArtistId(int id)
        {
            return Ok(_artistService.GetAlbumsByArtistId(id));
        }

        [HttpGet]
        [Route("{id}/songs")]
        public IActionResult GetSongsByArtistId(int id)
        {
            return Ok(_artistService.GetSongsByArtistId(id));
        }

        [HttpGet]
        [Route("{id}/reviews")]
        public IActionResult GetAlbumsReviewsByArtistId(int id)
        {
            return Ok(_reviewService.GetAlbumsReviewsByArtistId(id));
        }

        [HttpPost]
        [Route("")]
        public IActionResult CreateNewArtist([FromBody] ArtistInputModel artist)
        {
            var newId = _artistService.CreateNewArtist(artist);
            return CreatedAtRoute("GetArtistById", new { id = newId }, null);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateArtist([FromBody] ArtistInputModel artist, int id)
        {
            _artistService.UpdateArtist(id, artist);
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteArtist(int id)
        {
            _artistService.DeleteArtist(id);
            return NoContent();
        }
    }
}