using Microsoft.EntityFrameworkCore;
using RU.WebServices.SecretService.Models.Entities;

namespace RU.WebServices.SecretService.Repositories.Contexts
{
    public class SecretServiceDbContext : DbContext
    {
        public SecretServiceDbContext(DbContextOptions<SecretServiceDbContext> options)
        : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .HasOne(m => m.UserFrom)
                .WithMany(u => u.MessagesSent);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.UserTo)
                .WithMany(u => u.MessagesReceived);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<JwtToken> JwtTokens { get; set; }
    }
}