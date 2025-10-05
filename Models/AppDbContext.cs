using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>().OwnsOne(song => song.ChordGrid, gridBuilder =>
             {
                 gridBuilder.ToJson();
                 gridBuilder.OwnsMany(grid => grid.Columns);

             });
            modelBuilder.Entity<Song>().OwnsOne(song => song.MelodyGrid, gridBuilder =>
            {
                gridBuilder.ToJson();
                gridBuilder.OwnsMany(grid => grid.Columns);

            });

        }

        public DbSet<Song> Song { get; set; }
    }
}
