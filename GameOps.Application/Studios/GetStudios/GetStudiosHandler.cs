using GameOps.Application.Abstractions;
using GameOps.Domain.Entities;

namespace GameOps.Application.Studios.GetStudios
{
    public class GetStudiosHandler
    {
        private readonly IStudioRepository _studioRepository;

        public GetStudiosHandler(IStudioRepository studioRepository)
        {
            _studioRepository = studioRepository;
        }

        public async Task<List<Studio>> GetAllAsync()
        {
            return await _studioRepository.GetAllAsync();
        }

        public async Task<Studio?> GetByIdAsync(Guid id)
        {
            return await _studioRepository.GetByIdAsync(id);
        }
    }
}
