using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PowerLifting.Service.Exercises.Contracts;
using PowerLifting.Service.Exercises.DTO;
using PowerLifting.Service.Exercises.Exceptions;
using PowerLifting.Service.Exercises.Model;
using PowerLifting.Service.ServiceWrappers;

namespace PowerLifting.Service.Exercises
{
    public class ExerciseTypeService : IExerciseTypeService
    {
        private IMapper _mapper;
        private ConcurrentDictionary<int, ExerciseTypeDTO> _store;
        private IRepositoryWrapper _repo;

        public ExerciseTypeService(IRepositoryWrapper repo, IMapper mapper)
        {
            _store = new ConcurrentDictionary<int, ExerciseTypeDTO>();
            _repo = repo;
            _mapper = mapper;
        }

        public IEnumerable<ExerciseTypeDTO> GetAllExerciseTypes()
        {
            RefreshExerciseStore();
            return _store.Values;
        }

        private void RefreshExerciseStore()
        {
            if (!_store.IsEmpty)
                return;

            var categories = _repo.ExerciseType.GetAllExerciseTypes();
            var TypeDTOs = _mapper.Map<IEnumerable<ExerciseTypeDTO>>(categories);

            foreach (var exerciseDTO in TypeDTOs)
            {
                _store.AddOrUpdate(exerciseDTO.ExerciseTypeId, exerciseDTO, (key, olValue) => exerciseDTO);
            }
        }

        public async Task<ExerciseTypeDTO> GetExerciseTypeById(int id)
        {
            var exerciseType = await _repo.ExerciseType.GetExerciseTypeById(id);
            var exerciseTypeDTO = _mapper.Map<ExerciseTypeDTO>(exerciseType);
            return exerciseTypeDTO;
        }

        public async void UpdateExerciseType(ExerciseTypeDTO exerciseTypeDTO)
        {
            var exerciseTypeEntity = await _repo.ExerciseType.GetExerciseTypeById(exerciseTypeDTO.ExerciseTypeId);
            
            if (exerciseTypeEntity == null)
            {
                throw new ExerciseTypeNotFoundException("The ExerciseType associated with the given Id cannot be found");
            }
            _mapper.Map(exerciseTypeDTO, exerciseTypeEntity);
            _repo.ExerciseType.UpdateExerciseType(exerciseTypeEntity);
        }

        public async void DeleteExerciseType(ExerciseTypeDTO exerciseTypeDTO)
        {
            var exerciseTypeEntity = await _repo.ExerciseType.GetExerciseTypeById(exerciseTypeDTO.ExerciseTypeId);
            if (exerciseTypeEntity == null)
            {
                throw new ExerciseTypeNotFoundException("The ExerciseType associated with the given Id cannot be found");
            }
            _repo.ExerciseType.Delete(exerciseTypeEntity);
        }
    }
}
