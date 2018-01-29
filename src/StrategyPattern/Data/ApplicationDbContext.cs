using Microsoft.EntityFrameworkCore;
using StrategyPattern.Data.Entity;

namespace StrategyPattern.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<BusStopEntity> BusStops { get; set; }
        public DbSet<RouteEntity> Routes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BusStopEntity>()
                .HasMany(e => e.Routes)
                .WithOne(e => e.From);

            base.OnModelCreating(modelBuilder);
        }
    }
}
