using System;
using Powerlifting.Repository;
using Powerlifting.Service.ProgramExercises.Model;
using PowerLifting.Persistence;
using PowerLifting.Services.ProgramExercises;

namespace PowerLifting.Repository.Repositories
{
    public class ProgramExerciseRepository : RepositoryBase<ProgramExercise>, IProgramExerciseRepository
    {
        public ProgramExerciseRepository(PowerliftingContext context) : base(context)
        {
        }
    }
}
