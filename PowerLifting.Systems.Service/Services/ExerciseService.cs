using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PowerLifting.Entity.System.Exercises.DTOs;
using PowerLifting.Entity.System.Exercises.Models;
using PowerLifting.Systems.Contracts;
using PowerLifting.Systems.Contracts.Services;
using PowerLifting.Systems.Service.Exceptions;

namespace PowerLifting.Systems.Service.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly IMapper _mapper;
        private readonly ISystemWrapper _repo;
        private readonly ConcurrentDictionary<int, ExerciseDTO> _store;

        public ExerciseService(ISystemWrapper repo, IMapper mapper)
        {
            _repo = repo;
            _store = new ConcurrentDictionary<int, ExerciseDTO>();
            _mapper = mapper;
        }

        public async Task<IEnumerable<ExerciseDTO>> GetAllExercises()
        {
            await RefreshExerciseStore();
            return _store.Values;
        }

        private async Task RefreshExerciseStore()
        {
            if (!_store.IsEmpty)
                return;

            var exerciseDTOs = await _repo.Exercise.GetAllExercises();

            foreach (var exerciseDTO in exerciseDTOs)
                _store.AddOrUpdate(exerciseDTO.ExerciseId, exerciseDTO, (key, olValue) => exerciseDTO);
        }

        public async Task<ExerciseDTO> GetExerciseById(int id)
        {
            //var validator = new ExerciseValidator();
            //validator.ValidateExerciseId(id);
            var exercise = await _repo.Exercise.GetExerciseById(id);
            //validator.ValidateExerciseExists(exercise);
            return exercise;
        }

        public async Task<ExerciseDTO> GetExerciseByName(string exerciseName)
        {
            //var validator = new ExerciseValidator();
            //validator.ValidateExerciseId(id);
            var exercise = await _repo.Exercise.GetExerciseByName(exerciseName);
            //validator.ValidateExerciseExists(exercise);

            var exerciseDTO = _mapper.Map<ExerciseDTO>(exercise);
            return exerciseDTO;
        }

        public async void UpdateExercise(ExerciseDTO exerciseDTO)
        {
            var doesExist = await _repo.Exercise.DoesExerciseExist(exerciseDTO.ExerciseId);
            if (!doesExist) throw new ExerciseNotFoundException();

            var exercise = _mapper.Map<Exercise>(exerciseDTO);
            _repo.Exercise.UpdateExercise(exercise);
        }

        public async void DeleteExercise(ExerciseDTO exerciseDTO)
        {
            var exercise = await _repo.Exercise.GetExerciseById(exerciseDTO.ExerciseId);
            if (exercise == null) throw new ExerciseNotFoundException();

            var exerciseToDelete = _mapper.Map<Exercise>(exercise);
            _repo.Exercise.DeleteExercise(exerciseToDelete);
        }
    }
}