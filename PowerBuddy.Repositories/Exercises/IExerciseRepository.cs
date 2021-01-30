﻿using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using PowerBuddy.Data.DTOs.Exercises;

namespace PowerBuddy.Repositories.Exercises
{
    public interface IExerciseRepository
    {
        public Task<IEnumerable<ExerciseDTO>> GetAllExercises();

        public Task<IEnumerable<ExerciseMuscleGroupDTO>> GetAllExerciseMuscleGroups();

        public Task<IEnumerable<ExerciseTypeDTO>> GetAllExerciseTypes();
    }
}
