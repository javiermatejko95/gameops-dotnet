using GameOps.Application.Abstractions;
using GameOps.Infrastructure.Persistence;
using GameOps.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameOps.Infrastructure.Repositories
{
    public class StudioRepository : IStudioRepository
    {
        private readonly GameOpsDbContext _context;

        public StudioRepository(GameOpsDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Studio studio)
        {
            await _context.Studios.AddAsync(studio);
            await _context.SaveChangesAsync();
        }

        public async Task<Studio?> GetByIdAsync(Guid id)
        {
            return await _context.Studios
                .Include(x => x.Games)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await _context.Studios
                .AnyAsync(s => s.Name == name);
        }

        public async Task<List<Studio>> GetAllAsync()
        {
            return await _context.Studios
                .Include(x => x.Games)
                .ToListAsync();
        }

        public async Task RemoveAsync(Studio studio)
        {
            _context.Studios.Remove(studio);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Studio studio)
        {
            // New Games created by Studio.AddGame() are in Detached state.
            // We must explicitly mark them as Added so EF inserts them into the DB.
            foreach (var game in studio.Games)
            {
                var entry = _context.Entry(game);
                if (entry.State == EntityState.Detached)
                {
                    entry.State = EntityState.Added;
                }
            }
            await _context.SaveChangesAsync();
        }
    }
}
