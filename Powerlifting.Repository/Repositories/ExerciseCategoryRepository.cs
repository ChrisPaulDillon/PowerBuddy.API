using System;
using Powerlifting.Repository;
using Powerlifting.Services.ExerciseCategories.Model;
using PowerLifting.Persistence;
using PowerLifting.Services.ExerciseCategories;

namespace PowerLifting.Repository.Repositories
{
    public class ExerciseCategoryRepository : RepositoryBase<ExerciseCategory>, IExerciseCategoryRepository
    {
        public ExerciseCategoryRepository(PowerliftingContext context) : base(context)
        {
        }
    }
}
