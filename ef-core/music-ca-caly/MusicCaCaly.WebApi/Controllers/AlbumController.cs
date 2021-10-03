using Microsoft.AspNetCore.Mvc;
using MusicCaCaly.Services.Interfaces;

namespace MusicCaCaly.WebApi.Controllers
{
    [ApiController]
    [Route("albums")]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumService _albumService;
        private readonly IReviewService _reviewService;
        private readonly ISongService _songService;

        public AlbumController(IAlbumService albumService, IReviewService reviewService, ISongService songService)
        {
            _albumService = albumService;
            _reviewService = reviewService;
            _songService = songService;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetAlbumById(int id)
        {
            return Ok(_albumService.GetAlbumById(id));
        }

        [HttpGet]
        [Route("{id}/songs")]
        public IActionResult GetSongsByAlbumId(int id)
        {
            return Ok(_albumService.GetSongsByAlbumId(id));
        }

        [HttpGet]
        [Route("{id}/reviews")]
        public IActionResult GetReviewsByAlbumId(int id)
        {
            return Ok(_reviewService.GetReviewsByAlbumId(id));
        }

        [HttpPatch]
        [Route("{albumId}/songs/{songId}")]
        public IActionResult LinkSongToAlbum(int albumId, int songId)
        {
            _songService.LinkSongToAlbum(albumId, songId);
            return NoContent();
        }
    }
}