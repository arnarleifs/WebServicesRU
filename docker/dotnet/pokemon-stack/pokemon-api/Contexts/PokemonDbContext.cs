using Microsoft.EntityFrameworkCore;
using pokemon_api.Models.Entities;

namespace pokemon_api.Contexts;

public class PokemonDbContext : DbContext
{
    public PokemonDbContext(DbContextOptions<PokemonDbContext> options) : base(options) { }

    public DbSet<Pokemon> Pokemons { get; set; }
}