﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Powerlifting.Repository;
using Powerlifting.Service.Exercises.Model;
using PowerLifting.Persistence;
using PowerLifting.Services.Exercises;

namespace PowerLifting.Repository.Repositories
{
    public class ExerciseRepository : RepositoryBase<Exercise>, IExerciseRepository
    {
        public ExerciseRepository(PowerliftingContext context) : base(context)
        {
        }

        public IEnumerable<Exercise> GetAllExercises()
        {
            return PowerliftingContext.Set<Exercise>().ToList();
        }

        public async Task<Exercise> GetExerciseById(int id)
        {
            return await PowerliftingContext.Set<Exercise>().Where(c => c.ExerciseId == id).FirstOrDefaultAsync();
        }

        public void UpdateExercise(Exercise exercise)
        {
            Update(exercise);
            Save();
        }

        public void DeleteExercise(Exercise exercise)
        {
            Delete(exercise);
            Save();
        }
    }
}