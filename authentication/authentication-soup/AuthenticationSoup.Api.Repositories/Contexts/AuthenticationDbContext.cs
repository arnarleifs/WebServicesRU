using AuthenticationSoup.Api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationSoup.Api.Repositories.Contexts;

public class AuthenticationDbContext : DbContext
{
    public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; } = null!;
}