using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Powerlifting.Service.Exercises.Model;

namespace PowerLifting.Services.Exercises
{
    public interface IExerciseRepository
    {
        Task<IEnumerable<Exercise>> GetAllExercises();
        Task<Exercise> GetExerciseById(int id);
        void UpdateExercise(Exercise exercise);
        void DeleteExercise(Exercise exercise);
    }
}
