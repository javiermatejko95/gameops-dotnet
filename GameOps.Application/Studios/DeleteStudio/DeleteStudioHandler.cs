using GameOps.Application.Abstractions;
using GameOps.Application.Studios.CreateStudio;
using GamesOps.Domain.Entities;
using GamesOps.Domain.Exceptions;

namespace GameOps.Application.Studios.DeleteStudio
{
    public class DeleteStudioHandler
    {
        private readonly IStudioRepository _studioRepository;

        public DeleteStudioHandler(IStudioRepository studioRepository)
        {
            _studioRepository = studioRepository;
        }

        public async Task Handle(DeleteStudioCommand command)
        {
            Studio? studio = await _studioRepository.GetByIdAsync(command.id);

            if(studio is null)
            {
                throw new DomainException($"A studio with the id '{command.id}' was not found.");
            }            

            await _studioRepository.RemoveAsync(studio);
        }
    }
}
