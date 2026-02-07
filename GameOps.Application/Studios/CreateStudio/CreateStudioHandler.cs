using GameOps.Application.Abstractions;
using GameOps.Domain.Entities;
using GameOps.Domain.Exceptions;

namespace GameOps.Application.Studios.CreateStudio
{
    public class CreateStudioHandler
    {
        private readonly IStudioRepository _studioRepository;

        public CreateStudioHandler(IStudioRepository studioRepository)
        {
            _studioRepository = studioRepository;
        }

        public async Task<Guid> Handle(CreateStudioCommand command)
        {
            if (await _studioRepository.ExistsByNameAsync(command.Name))
            {
                throw new DomainException($"A studio with the name '{command.Name}' already exists.");
            }

            var studio = new Studio(command.Name);

            await _studioRepository.AddAsync(studio);

            return studio.Id;
        }
    }
}
