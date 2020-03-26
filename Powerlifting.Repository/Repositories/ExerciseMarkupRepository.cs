using System;
using Powerlifting.Repository;
using PowerLifting.Entities.DTOs;
using PowerLifting.Persistence;
using PowerLifting.Services.ExerciseMarkups;

namespace PowerLifting.Repository.Repositories
{
    public class ExerciseMarkupRepository : RepositoryBase<ExerciseMarkup>, IExerciseMarkupRepository
    {
        public ExerciseMarkupRepository(PowerliftingContext context) : base(context)
        {
        }
    }
}
