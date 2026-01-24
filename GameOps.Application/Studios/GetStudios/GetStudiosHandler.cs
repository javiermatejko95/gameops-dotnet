using GameOps.Application.Abstractions;
using GameOps.Application.Studios.DeleteStudio;
using GamesOps.Domain.Entities;
using GamesOps.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
