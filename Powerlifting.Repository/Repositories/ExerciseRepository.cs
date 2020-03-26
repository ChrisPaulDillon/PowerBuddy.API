using System;
using Powerlifting.Repository;
using Powerlifting.Service.Exercises.Model;
using PowerLifting.Persistence;
using PowerLifting.Services.Exercises;

namespace PowerLifting.Repository.Repositories
{
    public class ExerciseRepository : RepositoryBase<Exercise>, IExerciseRepository
    {
        public ExerciseRepository(PowerliftingContext context) : base (context)
        {
        }
    }
}
