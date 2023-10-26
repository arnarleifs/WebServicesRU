using Microsoft.AspNetCore.Mvc;
using pokemon_api.Services;

namespace pokemon_api.Controllers;

[ApiController]
[Route("[controller]")]
public class PokemonsController : ControllerBase
{
    private readonly IPokemonService _pokemonService;
    private readonly ILogger<PokemonsController> _logger;

    public PokemonsController(IPokemonService pokemonService, ILogger<PokemonsController> logger)
    {
        _pokemonService = pokemonService;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult GetAllPokemons()
    {
        try
        {
            var pokemons = _pokemonService.GetAllPokemons();
            return Ok(pokemons);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while getting all pokemons.");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpGet("{pokemonId}/image")]
    public async Task<IActionResult> GetImageForPokemon(int pokemonId)
    {
        try
        {
            var imageBytes = await _pokemonService.GetImageForPokemon(pokemonId);
            if (imageBytes == null)
            {
                return NotFound("Image not found");
            }

            return File(imageBytes, "image/png");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while getting the image for Pokemon with ID {pokemonId}", pokemonId);
            return StatusCode(500, "Internal server error");
        }
    }
}
