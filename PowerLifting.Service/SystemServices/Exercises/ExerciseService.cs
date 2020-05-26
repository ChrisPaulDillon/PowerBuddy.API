using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PowerLifting.Service.Exercises.Contracts;
using PowerLifting.Service.Exercises.DTO;
using PowerLifting.Service.Exercises.Exceptions;
using PowerLifting.Service.Exercises.Validators;

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

        public async Task<IEnumerable<TopLevelExerciseDTO>> GetAllExercises()
        {
            await RefreshExerciseStore();
            return _store.Values;
        }

        private async Task RefreshExerciseStore()
        {
            if (!_store.IsEmpty)
                return;

            var exercises = await _repo.Exercise.GetAllExercises();
            var exerciseDTOs = _mapper.Map<IEnumerable<TopLevelExerciseDTO>>(exercises);

            foreach (var exerciseDTO in exerciseDTOs)
                _store.AddOrUpdate(exerciseDTO.ExerciseId, exerciseDTO, (key, olValue) => exerciseDTO);
        }

        public async Task<ExerciseDTO> GetExerciseById(int id)
        {
            var validator = new ExerciseValidator();
            validator.ValidateExerciseId(id);
            var exercise = await _repo.Exercise.GetExerciseById(id);
            validator.ValidateExerciseExists(exercise);

            var exerciseDTO = _mapper.Map<ExerciseDTO>(exercise);
            return exerciseDTO;
        }

        public async void UpdateExercise(ExerciseDTO exerciseDTO)
        {
            var exercise = await _repo.Exercise.GetExerciseById(exerciseDTO.ExerciseId);
            if (exercise == null) throw new ExerciseNotFoundException();

            _mapper.Map(exerciseDTO, exercise);
            _repo.Exercise.UpdateExercise(exercise);
        }

        public async void DeleteExercise(ExerciseDTO exerciseDTO)
        {
            var exercise = await _repo.Exercise.GetExerciseById(exerciseDTO.ExerciseId);
            if (exercise == null) throw new ExerciseNotFoundException();

            _repo.Exercise.DeleteExercise(exercise);
        }

        public Task<IEnumerable<ExerciseDTO>> GetAllExercisesByMuscleGroupId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ExerciseDTO>> GetAllExercisesByExerciseTypeId(int exerciseTypeId)
        {
            var exercises = await _repo.Exercise.GetExerciseByExerciseTypeId(exerciseTypeId);
            //TODO
            var exerciseDTO = _mapper.Map<IEnumerable<ExerciseDTO>>(exercises);
            return exerciseDTO;
        }
    }
}