using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Service.Exercises.Model;
using PowerLifting.Services;

namespace PowerLifting.Service.Exercises.Contracts
{
    public interface IExerciseTypeRepository : IRepositoryBase<ExerciseType>
    {
        IEnumerable<ExerciseType> GetAllExerciseTypes();
        Task<ExerciseType> GetExerciseTypeById(int exerciseTypeId);
        void UpdateExerciseType(ExerciseType exerciseCategory);
        void DeleteExerciseType(ExerciseType exerciseCategory);
    }
}
