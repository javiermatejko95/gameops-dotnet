using GameOps.Application.Abstractions;
using GamesOps.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var studio = new Studio(command.Name);

            await _studioRepository.AddAsync(studio);

            return studio.Id;
        }
    }
}
