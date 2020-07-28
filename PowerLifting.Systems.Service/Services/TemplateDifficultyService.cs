using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PowerLifting.Data.DTOs.System;
using PowerLifting.Systems.Contracts.Services;

namespace PowerLifting.Systems.Service.Services
{
    public class TemplateDifficultyService : ITemplateDifficultyService
    {
        private readonly IMapper _mapper;
        private readonly ISystemWrapper _repo;
        private readonly ConcurrentDictionary<int, TemplateDifficultyDTO> _store;

        public TemplateDifficultyService(ISystemWrapper repo, IMapper mapper)
        {
            _repo = repo;
            _store = new ConcurrentDictionary<int, TemplateDifficultyDTO>();
            _mapper = mapper;
        }

        public async Task<IEnumerable<TemplateDifficultyDTO>> GetAllTemplateDifficulties()
        {
            await RefreshTemplateDifficultyStore();
            return _store.Values;
        }

        private async Task RefreshTemplateDifficultyStore()
        {
            if (!_store.IsEmpty)
                return;

            var templateDifficulties = await _repo.TemplateDifficulty.GetAllTemplateDifficulties();

            foreach (var templateDifficultyDTO in templateDifficulties)
                _store.AddOrUpdate(templateDifficultyDTO.TemplateDifficultyId, templateDifficultyDTO, (key, olValue) => templateDifficultyDTO);
        }
    }
}