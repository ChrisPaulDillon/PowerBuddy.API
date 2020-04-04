﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Powerlifting.Repository;
using PowerLifting.Persistence;
using PowerLifting.Service.Exercises.Contracts;
using PowerLifting.Service.Exercises.Model;

namespace PowerLifting.Repository
{
    public class ExerciseMuscleGroupRepository : RepositoryBase<ExerciseMuscleGroup>, IExerciseMuscleGroupRepository
    {

        public ExerciseMuscleGroupRepository(PowerliftingContext context) : base(context)
        {
        }

        public IEnumerable<ExerciseMuscleGroup> GetAllExerciseMuscleGroups()
        {
            return PowerliftingContext.Set<ExerciseMuscleGroup>().ToList();
        }

        public async Task<ExerciseMuscleGroup> GetExerciseMuscleGroupById(int exerciseTypeId)
        {
            return await PowerliftingContext.Set<ExerciseMuscleGroup>().Where(c => c.ExerciseMuscleGroupId == exerciseTypeId).FirstOrDefaultAsync();
        }

        public void UpdateExerciseMuscleGroup(ExerciseMuscleGroup exerciseMuscleGroup)
        {
            Update(exerciseMuscleGroup);
            Save();
        }

        public void DeleteExerciseMuscleGroup(ExerciseMuscleGroup exerciseMuscleGroup)
        {
            Delete(exerciseMuscleGroup);
            Save();
        }
    }
}