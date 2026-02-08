using GameOps.Application.Abstractions;
using GameOps.Contracts.Studios;

namespace GameOps.Application.Studios.GetStudios
{
    public class GetStudiosHandler
    {
        private readonly IStudioRepository _studioRepository;

        public GetStudiosHandler(IStudioRepository studioRepository)
        {
            _studioRepository = studioRepository;
        }

        public async Task<List<StudioDto>> GetAllAsync()
        {
            var studios = await _studioRepository.GetAllAsync();

            return studios.Select(studio => new StudioDto
            {
                Id = studio.Id,
                Name = studio.Name,
                CreatedAt = studio.CreatedAt
            }).ToList();
        }

        public async Task<StudioDto?> GetByIdAsync(Guid id)
        {
            var studio = await _studioRepository.GetByIdAsync(id);
            if (studio is null) return null;

            return new StudioDto
            {
                Id = studio.Id,
                Name = studio.Name,
                CreatedAt = studio.CreatedAt
            };
        }
    }
}
