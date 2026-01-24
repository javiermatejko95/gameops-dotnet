using GamesOps.Domain.Entities;

namespace GameOps.Application.Abstractions
{
    public interface IStudioRepository
    {
        Task AddAsync(Studio studio);
        Task<Studio?> GetByIdAsync(Guid id);
    }
}
