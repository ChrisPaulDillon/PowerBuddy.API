﻿using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PowerLifting.Entity.System.ExerciseMuscleGroups.DTOs;
using PowerLifting.Entity.System.ExerciseMuscleGroups.Models;
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

            var exerciseMuscleGroupDTOs = await _repo.ExerciseMuscleGroup.GetAllExerciseMuscleGroups();

            foreach (var exerciseMuscleGroupDTO in exerciseMuscleGroupDTOs)
                _store.AddOrUpdate(exerciseMuscleGroupDTO.ExerciseMuscleGroupId, exerciseMuscleGroupDTO, (key, olValue) => exerciseMuscleGroupDTO);
        }

        public async Task<bool> UpdateExerciseMuscleGroup(ExerciseMuscleGroupDTO exerciseMuscleGroupDTO)
        {
            var exerciseMuscleGroup = await _repo.ExerciseMuscleGroup.GetExerciseMuscleGroupById(exerciseMuscleGroupDTO.ExerciseMuscleGroupId);

            if (exerciseMuscleGroup == null) throw new ExerciseMuscleGroupNotFoundException();

            return await _repo.ExerciseMuscleGroup.UpdateExerciseMuscleGroup(exerciseMuscleGroupDTO);
        }

        public async Task<bool> DeleteExerciseMuscleGroup(ExerciseMuscleGroupDTO exerciseMuscleGroupDTO)
        {
            var exerciseMuscleGroup = await _repo.ExerciseMuscleGroup.GetExerciseMuscleGroupById(exerciseMuscleGroupDTO.ExerciseMuscleGroupId);

            if (exerciseMuscleGroup == null) throw new ExerciseMuscleGroupNotFoundException();
            var exerciseMG = _mapper.Map<ExerciseMuscleGroup>(exerciseMuscleGroup);

            return await _repo.ExerciseMuscleGroup.DeleteExerciseMuscleGroup(exerciseMuscleGroupDTO);
        }

    }
}