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
            modelBuilder.Entity<Grids>().OwnsMany(grids => grids.ChordGrid, builder => builder.ToJson());
            modelBuilder.Entity<Grids>().OwnsMany(grids => grids.MelodyGrid, builder => builder.ToJson());

        }

        public DbSet<Grids> Grids { get; set; }
    }
}
