using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Powerlifting.Service.Exercises.Model;

namespace PowerLifting.Services.Exercises.Contracts
{
    public interface IExerciseRepository : IRepositoryBase<Exercise>
    {
        IEnumerable<Exercise> GetAllExercises();
        Task<Exercise> GetExerciseById(int id);
        void UpdateExercise(Exercise exercise);
        void DeleteExercise(Exercise exercise);
    }
}
