using GamesOps.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameOps.Infrastructure.Persistence
{
    public class GameOpsDbContext : DbContext
    {
        public DbSet<Studio> Studios => Set<Studio>();

        public GameOpsDbContext(DbContextOptions<GameOpsDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GameOpsDbContext).Assembly);
        }
    }
}
