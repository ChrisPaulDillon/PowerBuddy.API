using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Collections.Concurrent;
using AutoMapper;
using Powerlifting.Service.Exercises.DTO;
using Powerlifting.Service.Exercises;
using PowerLifting.Service.ServiceWrappers;

namespace PowerLifting.Service.Exercises
{
    public class ExerciseService : IExerciseService
    {
        private ConcurrentDictionary<int, ExerciseDTO> _store;
        private IMapper _mapper;
        private IRepositoryWrapper _repo;

        public ExerciseService(IRepositoryWrapper repo, IMapper mapper)
        {
            _repo = repo;
            _store = new ConcurrentDictionary<int, ExerciseDTO>();
            _mapper = mapper;
        }

        public IEnumerable<ExerciseDTO> GetAllExercises()
        {
            RefreshExerciseStore();
            return _store.Values;
        }

        public void RefreshExerciseStore()
        {
            if(!_store.IsEmpty)
                return;

            var exercises = _repo.Exercise.GetAllExercises();
            var exerciseDTOs = _mapper.Map<IEnumerable<ExerciseDTO>>(exercises);

            foreach(var exerciseDTO in exerciseDTOs)
            {
                _store.AddOrUpdate(exerciseDTO.ExerciseId, exerciseDTO, (key, olValue) => exerciseDTO);
            }
        }

        public async Task<ExerciseDTO> GetExerciseById(int id)
        {
            var exercise = await _repo.Exercise.GetExerciseById(id);
            var exerciseDTO = _mapper.Map<ExerciseDTO>(exercise);
            return exerciseDTO;
        }

        public async void UpdateExercise(ExerciseDTO exerciseDTO)
        {
            var exercise = await _repo.Exercise.GetExerciseById(exerciseDTO.ExerciseId);
            if (exercise == null)
            {
                //throw new UserNotFoundException();
                //TODO
            }
            _mapper.Map(exerciseDTO, exercise);
            _repo.Exercise.UpdateExercise(exercise);
        }

        public async void DeleteExercise(ExerciseDTO exerciseDTO)
        {
            var exercise = await _repo.Exercise.GetExerciseById(exerciseDTO.ExerciseId);
            if (exercise == null)
            {
                //throw new UserNotFoundException();
            }
            _repo.Exercise.DeleteExercise(exercise);
        }

        public Task<ExerciseDTO> GetExerciseByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
