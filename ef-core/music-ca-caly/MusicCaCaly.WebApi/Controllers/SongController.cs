using Microsoft.AspNetCore.Mvc;
using MusicCaCaly.Models.InputModels;
using MusicCaCaly.Services.Interfaces;

namespace MusicCaCaly.WebApi.Controllers
{
    [ApiController]
    [Route("songs")]
    public class SongController : ControllerBase
    {
        private readonly ISongService _songService;

        public SongController(ISongService songService)
        {
            _songService = songService;
        }

        [HttpGet]
        [Route("{id}", Name = "GetSongById")]
        public IActionResult GetSongById(int id)
        {
            return Ok(_songService.GetSongById(id));
        }

        [HttpPost]
        [Route("")]
        public IActionResult CreateNewSong([FromBody] SongInputModel song)
        {
            var newId = _songService.CreateNewSong(song);
            return CreatedAtRoute("GetSongById", new { id = newId }, null);
        }
    }
}