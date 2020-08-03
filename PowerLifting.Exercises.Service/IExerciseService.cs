using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Data.DTOs.Exercises;
using PowerLifting.Data.DTOs.System;
using PowerLifting.Data.Entities.Exercises;

namespace PowerLifting.Exercises.Service
{
    public interface IExerciseService
    {
        Task<IEnumerable<ExerciseDTO>> GetAllExercises();

        Task<IEnumerable<ExerciseDTO>> GetAllUnapprovedExercises();

        Task<bool> ApproveExercise(int exerciseId, string userId);

        Task<IEnumerable<TopLevelExerciseDTO>> GetAllExercisesBySport(string exerciseSport);

        Task<Exercise> GetExerciseById(int id);

        Task<Exercise> CreateExercise(CExerciseDTO exercise);

        Task<bool> UpdateExercise(ExerciseDTO exercise);

        Task<bool> DeleteExercise(ExerciseDTO exercise);
    }
}