using Microsoft.EntityFrameworkCore;
using MusicCaCaly.Repositories.Entities;

namespace MusicCaCaly.Repositories.Contexts
{
    public class MusicDbContext : DbContext
    {
        public MusicDbContext(DbContextOptions<MusicDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Manual configuration of relations (many-to-many)
            modelBuilder.Entity<AlbumArtist>()
                .HasKey(x => new { x.AlbumId, x.ArtistId });
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<AlbumArtist> AlbumArtists { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Song> Songs { get; set; }
    }
}