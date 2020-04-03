using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
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

        public void Create(ExerciseMuscleGroup entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(ExerciseMuscleGroup entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteExerciseType(ExerciseMuscleGroup exerciseMuscleGroup)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ExerciseMuscleGroup> FindAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<ExerciseMuscleGroup> FindByCondition(Expression<Func<ExerciseMuscleGroup, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExerciseMuscleGroup> GetAllExerciseMuscleGroups()
        {
            throw new NotImplementedException();
        }

        public Task<ExerciseMuscleGroup> GetExerciseMuscleGroupById(int exerciseTypeId)
        {
            throw new NotImplementedException();
        }

        public void Update(ExerciseMuscleGroup entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateExerciseType(ExerciseMuscleGroup exerciseMuscleGroup)
        {
            throw new NotImplementedException();
        }
    }
}
