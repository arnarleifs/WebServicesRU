using pokemon_api.Models.Dtos;

namespace pokemon_api.Services;

public interface IPokemonService
{
    IEnumerable<PokemonDto> GetAllPokemons();
    Task<byte[]> GetImageForPokemon(int pokemonId);
}