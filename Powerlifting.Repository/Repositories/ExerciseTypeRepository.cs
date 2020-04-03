using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Powerlifting.Repository;
using PowerLifting.Persistence;
using PowerLifting.Service.Exercises.Contracts;
using PowerLifting.Service.Exercises.Model;

namespace PowerLifting.Repository.Repositories
{
    public class ExerciseTypeRepository : RepositoryBase<ExerciseType>, IExerciseTypeRepository
    {
        public ExerciseTypeRepository(PowerliftingContext context) : base(context)
        {
        }

        public void DeleteExerciseType(ExerciseType exerciseCategory)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExerciseType> GetAllExerciseTypes()
        {
            throw new NotImplementedException();
        }

        public Task<ExerciseType> GetExerciseTypeById(int exerciseTypeId)
        {
            throw new NotImplementedException();
        }

        public void UpdateExerciseType(ExerciseType exerciseCategory)
        {
            throw new NotImplementedException();
        }
    }
}
