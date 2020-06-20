using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PowerLifting.Entity.System.Exercises.DTO;
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

        public ExerciseService(ISystemWrapper repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ExerciseDTO>> GetAllExercises()
        {
            return await _repo.Exercise.GetAllExercises();
        }

        public async Task<IEnumerable<ExerciseDTO>> GetAllExercisesBySport(string exerciseSport)
        {
            return await _repo.Exercise.GetAllExercisesBySport(exerciseSport);
        }

        public async Task<ExerciseDTO> GetExerciseById(int id)
        {
            //var validator = new ExerciseValidator();
            //validator.ValidateExerciseId(id);
            var exercise = await _repo.Exercise.GetExerciseById(id);
            //validator.ValidateExerciseExists(exercise);
            return exercise;
        }

        public async Task<Exercise> CreateExercise(CExerciseDTO exerciseDTO)
        {
            var doesExist = await _repo.Exercise.DoesExerciseNameExist(exerciseDTO.ExerciseName);
            if (doesExist) throw new ExerciseAlreadyExistsException();

            return new Exercise();
            //return _repo.Exercise.cre(exerciseDTO);
        }

        public async Task<bool> UpdateExercise(ExerciseDTO exerciseDTO)
        {
            var doesExist = await _repo.Exercise.DoesExerciseExist(exerciseDTO.ExerciseId);
            if (!doesExist) throw new ExerciseNotFoundException();

            return await _repo.Exercise.UpdateExercise(exerciseDTO);
        }

        public async Task<bool> DeleteExercise(ExerciseDTO exerciseDTO)
        {
            var exercise = await _repo.Exercise.GetExerciseById(exerciseDTO.ExerciseId);
            if (exercise == null) throw new ExerciseNotFoundException();

            return await _repo.Exercise.DeleteExercise(exerciseDTO);
        }
    }
}