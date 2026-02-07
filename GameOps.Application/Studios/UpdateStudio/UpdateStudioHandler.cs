using GameOps.Application.Abstractions;
using GameOps.Domain.Exceptions;

namespace GameOps.Application.Studios.RenameStudio
{
    public class UpdateStudioHandler
    {
        private readonly IStudioRepository _studioRepository;

        public UpdateStudioHandler(IStudioRepository studioRepository)
        {
            _studioRepository = studioRepository;
        }

        public async Task Handle(UpdateStudioCommand command)
        {
            var studio = await _studioRepository.GetByIdAsync(command.Id);

            if (studio is null)
            {
                throw new Exception("Studio not found");
            }

            var exists = await _studioRepository.ExistsByNameAsync(command.Name);

            if (exists && studio.Name == command.Name)
            {
                throw new Exception("Studio name already exists");
            }

            studio.Rename(command.Name);

            await _studioRepository.UpdateAsync(studio);
        }
    }
}
