using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Service.Exercises.Model;
using PowerLifting.Services;

namespace PowerLifting.Service.Exercises.Contracts
{
    public interface IExerciseMuscleGroupRepository : IRepositoryBase<ExerciseMuscleGroup>
    {
        IEnumerable<ExerciseMuscleGroup> GetAllExerciseMuscleGroups();
        Task<ExerciseMuscleGroup> GetExerciseMuscleGroupById(int exerciseTypeId);
        void UpdateExerciseType(ExerciseMuscleGroup exerciseMuscleGroup);
        void DeleteExerciseType(ExerciseMuscleGroup exerciseMuscleGroup);
    }
}
