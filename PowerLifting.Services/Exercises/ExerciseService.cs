using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Collections.Concurrent;
using AutoMapper;
using Powerlifting.Service.Exercises.DTO;
using Powerlifting.Service.Exercises.Model;
using PowerLifting.Services.Exercises;

namespace Powerlifting.Service.Exercises
{
    public class ExerciseService : IExerciseService
    {
        private ConcurrentDictionary<int, ExerciseDTO> _store;
        private IMapper _mapper;
        private IExerciseRepository _repo;

        public ExerciseService(IExerciseRepository repo, IMapper mapper)
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

            var exercises = _repo.GetAllExercises();
            var exerciseDTOs = _mapper.Map<IEnumerable<ExerciseDTO>>(exercises);

            foreach(var exerciseDTO in exerciseDTOs)
            {
                _store.AddOrUpdate(exerciseDTO.ExerciseId, exerciseDTO, (key, olValue) => exerciseDTO);
            }
        }

        public async Task<ExerciseDTO> GetExerciseById(int id)
        {
            var exercise = await _repo.GetExerciseById(id);
            var exerciseDTO = _mapper.Map<ExerciseDTO>(exercise);
            return exerciseDTO;
        }

        public async void UpdateExercise(ExerciseDTO exerciseDTO)
        {
            var exercise = await _repo.GetExerciseById(exerciseDTO.ExerciseId);
            if (exercise == null)
            {
                //throw new UserNotFoundException();
                //TODO
            }
            _mapper.Map(exerciseDTO, exercise);
            _repo.UpdateExercise(exercise);
        }

        public async void DeleteExercise(ExerciseDTO exerciseDTO)
        {
            var exercise = await _repo.GetExerciseById(exerciseDTO.ExerciseId);
            if (exercise == null)
            {
                //throw new UserNotFoundException();
            }
            _repo.DeleteExercise(exercise);
        }

        public Task<ExerciseDTO> GetExerciseByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
