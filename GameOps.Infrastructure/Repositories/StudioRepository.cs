using GameOps.Application.Abstractions;
using GameOps.Infrastructure.Persistence;
using GamesOps.Domain.Entities;
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
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await _context.Studios
                .AnyAsync(s => s.Name == name);
        }

        public async Task<List<Studio>> GetAllAsync()
        {
            return await _context.Studios.ToListAsync();
        }

        public async Task RemoveAsync(Studio studio)
        {
            _context.Studios.Remove(studio);
            await _context.SaveChangesAsync();
        }
    }
}
