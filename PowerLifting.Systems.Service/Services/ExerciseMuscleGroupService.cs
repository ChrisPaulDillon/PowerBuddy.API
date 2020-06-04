﻿using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PowerLifting.Entity.System.ExerciseMuscleGroups.DTOs;
using PowerLifting.Systems.Contracts.Services;
using PowerLifting.Systems.Service.Exceptions;

namespace PowerLifting.Systems.Service.Services
{
    public class ExerciseMuscleGroupService : IExerciseMuscleGroupService
    {
        private readonly IMapper _mapper;
        private readonly ISystemWrapper _repo;
        private readonly ConcurrentDictionary<int, ExerciseMuscleGroupDTO> _store;

        public ExerciseMuscleGroupService(ISystemWrapper repo, IMapper mapper)
        {
            _repo = repo;
            _store = new ConcurrentDictionary<int, ExerciseMuscleGroupDTO>();
            _mapper = mapper;
        }

        public async Task<IEnumerable<ExerciseMuscleGroupDTO>> GetAllExerciseMuscleGroups()
        {
            await RefreshExerciseStore();
            return _store.Values;
        }

        private async Task RefreshExerciseStore()
        {
            if (!_store.IsEmpty)
                return;

            var exercises = await _repo.ExerciseMuscleGroup.GetAllExerciseMuscleGroups();
            var exerciseDTOs = _mapper.Map<IEnumerable<ExerciseMuscleGroupDTO>>(exercises);

            foreach (var exerciseMuscleGroupDTO in exerciseDTOs)
                _store.AddOrUpdate(exerciseMuscleGroupDTO.ExerciseMuscleGroupId, exerciseMuscleGroupDTO,(key, olValue) => exerciseMuscleGroupDTO);
        }

        public async Task<ExerciseMuscleGroupDTO> GetExerciseMuscleGroupById(int exerciseMuscleGroupId)
        {
            var exercise = await _repo.Exercise.GetExerciseById(exerciseMuscleGroupId);
            var exerciseDTO = _mapper.Map<ExerciseMuscleGroupDTO>(exercise);
            return exerciseDTO;
        }

        public async Task UpdateExerciseMuscleGroup(ExerciseMuscleGroupDTO exerciseMuscleGroupDTO)
        {
            var exerciseMuscleGroup =
                await _repo.ExerciseMuscleGroup.GetExerciseMuscleGroupById(exerciseMuscleGroupDTO.ExerciseMuscleGroupId);

            if (exerciseMuscleGroup == null)
                throw new ExerciseMuscleGroupNotFoundException();

            _mapper.Map(exerciseMuscleGroupDTO, exerciseMuscleGroup);
            _repo.ExerciseMuscleGroup.UpdateExerciseMuscleGroup(exerciseMuscleGroup);
        }

        public async Task DeleteExerciseMuscleGroup(int exerciseMuscleGroupId)
        {
            var exerciseMuscleGroup = await _repo.Exercise.GetExerciseById(exerciseMuscleGroupId);

            if (exerciseMuscleGroup == null) throw new ExerciseMuscleGroupNotFoundException();
            _repo.Exercise.DeleteExercise(exerciseMuscleGroup);
        }

    }
}