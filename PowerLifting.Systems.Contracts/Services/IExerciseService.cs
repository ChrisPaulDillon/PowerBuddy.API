using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Entity.System.Exercises.DTOs;

namespace PowerLifting.Systems.Contracts.Services
{
    public interface IExerciseService
    {
        /// <summary>
        /// Gets a top level overview of all exercises available
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ExerciseDTO>> GetAllExercises();

        /// <summary>
        /// Gets a specific exercise by id and includes its type and muscle groups worked
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ExerciseDTO> GetExerciseById(int id);

        Task<ExerciseDTO> GetExerciseByName(string exerciseName);

        void UpdateExercise(ExerciseDTO exercise);
        void DeleteExercise(ExerciseDTO exercise);
    }
}