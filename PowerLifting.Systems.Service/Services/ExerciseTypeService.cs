using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PowerLifting.Entity.System.ExerciseTypes.DTOs;
using PowerLifting.Entity.System.ExerciseTypes.Models;
using PowerLifting.Systems.Contracts.Services;
using PowerLifting.Systems.Service.Exceptions;

namespace PowerLifting.Systems.Service.Services
{
    public class ExerciseTypeService : IExerciseTypeService
    {
        private readonly IMapper _mapper;
        private readonly ISystemWrapper _repo;
        private readonly ConcurrentDictionary<int, ExerciseTypeDTO> _store;

        public ExerciseTypeService(ISystemWrapper repo, IMapper mapper)
        {
            _store = new ConcurrentDictionary<int, ExerciseTypeDTO>();
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ExerciseTypeDTO>> GetAllExerciseTypes()
        {
            await RefreshExerciseStore();
            return _store.Values;
        }

        private async Task RefreshExerciseStore()
        {
            if (!_store.IsEmpty)
                return;

            var exerciseTypes = await _repo.ExerciseType.GetAllExerciseTypes();

            foreach (var exerciseDTO in exerciseTypes)
                _store.AddOrUpdate(exerciseDTO.ExerciseTypeId, exerciseDTO, (key, olValue) => exerciseDTO);
        }

        public async Task<ExerciseTypeDTO> GetExerciseTypeById(int id)
        {
            var exerciseType = await _repo.ExerciseType.GetExerciseTypeById(id);
            return exerciseType;
        }

        public async Task UpdateExerciseType(ExerciseTypeDTO exerciseTypeDTO)
        {
            var exerciseTypeEntity = await _repo.ExerciseType.GetExerciseTypeById(exerciseTypeDTO.ExerciseTypeId);
            if (exerciseTypeEntity == null) throw new ExerciseTypeNotFoundException();

            var exerciseType = _mapper.Map<ExerciseType>(exerciseTypeDTO);
            _repo.ExerciseType.UpdateExerciseType(exerciseType);
        }

        public async Task DeleteExerciseType(int exerciseTypeId)
        {
            var exerciseTypeEntity = await _repo.ExerciseType.GetExerciseTypeById(exerciseTypeId);
            if (exerciseTypeEntity == null) throw new ExerciseTypeNotFoundException();

            var exerciseType = _mapper.Map<ExerciseType>(exerciseTypeEntity);
            _repo.ExerciseType.Delete(exerciseType);
        }
    }
}