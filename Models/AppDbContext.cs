using Microsoft.EntityFrameworkCore;

namespace Api.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>().OwnsMany(song => song.ChordGrid, builder => builder.ToJson());
            modelBuilder.Entity<Song>().OwnsMany(song => song.MelodyGrid, builder => builder.ToJson());

        }

        public DbSet<Song> Song { get; set; }
    }
}
