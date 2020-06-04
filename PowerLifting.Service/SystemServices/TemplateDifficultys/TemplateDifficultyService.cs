using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PowerLifting.RepositoryMediator;
using PowerLifting.Service.SystemServices.TemplateDifficultys.DTO;

namespace PowerLifting.Service.SystemServices.TemplateDifficultys
{
    public class TemplateDifficultyService : ITemplateDifficultyService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repo;
        private readonly ConcurrentDictionary<int, TemplateDifficultyDTO> _store;

        public TemplateDifficultyService(IRepositoryWrapper repo, IMapper mapper)
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

            var exercises = await _repo.Exercise.GetAllExercises();
            var exerciseDTOs = _mapper.Map<IEnumerable<TemplateDifficultyDTO>>(exercises);

            foreach (var templateDifficultyDTO in exerciseDTOs)
                _store.AddOrUpdate(templateDifficultyDTO.TemplateDifficultyId, templateDifficultyDTO, (key, olValue) => templateDifficultyDTO);
        }
    }
}