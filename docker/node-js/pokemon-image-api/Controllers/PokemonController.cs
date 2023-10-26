using Microsoft.AspNetCore.Mvc;

namespace pokemon_image_api.Controllers
{
    [Route("api/pokemons")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        [HttpGet("{pokemonId}/image")]
        public IActionResult GetImageForPokemon(int pokemonId)
        {
            var b = System.IO.File.ReadAllBytes($"./sprites/{pokemonId}.png");
            return File(b, "image/png");
        }
    }
}
