using GameOps.Domain.Entities;

namespace GameOps.Application.Abstractions
{
    public interface IStudioRepository
    {
        Task AddAsync(Studio studio);
        Task<Studio?> GetByIdAsync(Guid id);
        Task<List<Studio>> GetAllAsync();
        Task<bool> ExistsByNameAsync(string name);
        Task RemoveAsync(Studio studio);
        Task UpdateAsync(Studio studio);
    }
}
