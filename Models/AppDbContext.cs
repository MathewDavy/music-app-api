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
            modelBuilder.Entity<Grid>().OwnsMany(grid => grid.Columns, builder => builder.ToJson());
        }

        public DbSet<Grid> Grid { get; set; }
    }
}
