using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PowerLifting.Service.Exercises.Contracts;
using PowerLifting.Service.Exercises.DTO;
using PowerLifting.Service.Exercises.Exceptions;

namespace PowerLifting.Service.Exercises
{
    public class ExerciseTypeService : IExerciseTypeService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repo;
        private readonly ConcurrentDictionary<int, ExerciseTypeDTO> _store;

        public ExerciseTypeService(IRepositoryWrapper repo, IMapper mapper)
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

            var categories = await _repo.ExerciseType.GetAllExerciseTypes();
            var exerciseTypeDTOs = _mapper.Map<IEnumerable<ExerciseTypeDTO>>(categories);

            foreach (var exerciseDTO in exerciseTypeDTOs)
                _store.AddOrUpdate(exerciseDTO.ExerciseTypeId, exerciseDTO, (key, olValue) => exerciseDTO);
        }

        public async Task<ExerciseTypeDTO> GetExerciseTypeById(int id)
        {
            var exerciseType = await _repo.ExerciseType.GetExerciseTypeById(id);
            var exerciseTypeDTO = _mapper.Map<ExerciseTypeDTO>(exerciseType);
            return exerciseTypeDTO;
        }

        public async Task UpdateExerciseType(ExerciseTypeDTO exerciseTypeDTO)
        {
            var exerciseTypeEntity = await _repo.ExerciseType.GetExerciseTypeById(exerciseTypeDTO.ExerciseTypeId);
            if (exerciseTypeEntity == null) throw new ExerciseTypeNotFoundException();

            _mapper.Map(exerciseTypeDTO, exerciseTypeEntity);
            _repo.ExerciseType.UpdateExerciseType(exerciseTypeEntity);
        }

        public async Task DeleteExerciseType(int exerciseTypeId)
        {
            var exerciseTypeEntity = await _repo.ExerciseType.GetExerciseTypeById(exerciseTypeId);
            if (exerciseTypeEntity == null) throw new ExerciseTypeNotFoundException();
            _repo.ExerciseType.Delete(exerciseTypeEntity);
        }
    }
}