using pokemon_api.Contexts;
using pokemon_api.Models.Dtos;

namespace pokemon_api.Services;

public class PokemonService : IPokemonService
{
    private readonly HttpClient _httpClient;
    private readonly PokemonDbContext _dbContext;

    public PokemonService(HttpClient httpClient, PokemonDbContext dbContext)
    {
        _httpClient = httpClient;
        _dbContext = dbContext;
    }

    public IEnumerable<PokemonDto> GetAllPokemons()
        => _dbContext.Pokemons.Select(p => new PokemonDto
        {
            Name = p.Name,
            Url = p.Url
        }).ToList();

    public async Task<byte[]> GetImageForPokemon(int pokemonId)
        => await _httpClient.GetByteArrayAsync($"/api/pokemons/{pokemonId}/image");
}