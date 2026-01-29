using GameOps.Application.Abstractions;
using GamesOps.Domain.Exceptions;

namespace GameOps.Application.Games.CreateGame
{
    public class AddGameToStudioHandler
    {
        private readonly IStudioRepository _studioRepository;

        public AddGameToStudioHandler(IStudioRepository studioRepository)
        {
            _studioRepository = studioRepository;
        }

        public async Task Handle(AddGameToStudioCommand command)
        {
            var studio = await _studioRepository.GetByIdAsync(command.StudioId) 
                ?? throw new DomainException($"A studio with the name '{command.Name}' doesn't exist.");

            studio.AddGame(command.Name);

            await _studioRepository.UpdateAsync(studio);
        }
    }
}
