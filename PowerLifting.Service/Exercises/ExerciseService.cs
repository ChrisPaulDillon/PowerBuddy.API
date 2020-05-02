using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PowerLifting.Service.Exercises.Contracts;
using PowerLifting.Service.Exercises.DTO;
using PowerLifting.Service.Exercises.Exceptions;
using PowerLifting.Service.ServiceWrappers;

namespace PowerLifting.Service.Exercises
{
    public class ExerciseService : IExerciseService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repo;
        private readonly ConcurrentDictionary<int, TopLevelExerciseDTO> _store;

        public ExerciseService(IRepositoryWrapper repo, IMapper mapper)
        {
            _repo = repo;
            _store = new ConcurrentDictionary<int, TopLevelExerciseDTO>();
            _mapper = mapper;
        }

        public IEnumerable<TopLevelExerciseDTO> GetAllExercises()
        {
            RefreshExerciseStore();
            return _store.Values;
        }

        public void RefreshExerciseStore()
        {
            if (!_store.IsEmpty)
                return;

            var exercises = _repo.Exercise.GetAllExercises();
            var exerciseDTOs = _mapper.Map<IEnumerable<TopLevelExerciseDTO>>(exercises);

            foreach (var exerciseDTO in exerciseDTOs)
                _store.AddOrUpdate(exerciseDTO.ExerciseId, exerciseDTO, (key, olValue) => exerciseDTO);
        }

        public async Task<ExerciseDTO> GetExerciseById(int id)
        {
            var exercise = await _repo.Exercise.GetExerciseById(id);
            if (exercise == null)
                throw new ExerciseNotFoundException("The Exercise associated with the given Id cannot be found");
            var exerciseDTO = _mapper.Map<ExerciseDTO>(exercise);
            return exerciseDTO;
        }

        public async void UpdateExercise(ExerciseDTO exerciseDTO)
        {
            var exercise = await _repo.Exercise.GetExerciseById(exerciseDTO.ExerciseId);
            if (exercise == null)
                throw new ExerciseNotFoundException("The Exercise associated with the given Id cannot be found");
            _mapper.Map(exerciseDTO, exercise);
            _repo.Exercise.UpdateExercise(exercise);
        }

        public async void DeleteExercise(ExerciseDTO exerciseDTO)
        {
            var exercise = await _repo.Exercise.GetExerciseById(exerciseDTO.ExerciseId);
            if (exercise == null)
                throw new ExerciseNotFoundException("The Exercise associated with the given Id cannot be found");
            _repo.Exercise.DeleteExercise(exercise);
        }

        public Task<IEnumerable<ExerciseDTO>> GetAllExercisesByMuscleGroupId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ExerciseDTO>> GetAllExercisesByExerciseTypeId(int exerciseTypeId)
        {
            var exercises = await _repo.Exercise.GetExerciseByExerciseTypeId(exerciseTypeId);
            if (exercises == null) throw new ExerciseNotFoundException("No exercises found under this category!");
            var exerciseDTO = _mapper.Map<IEnumerable<ExerciseDTO>>(exercises);
            return exerciseDTO;
        }
    }
}