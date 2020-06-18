using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Entity.System.Exercises.DTO;
using PowerLifting.Entity.System.Exercises.DTOs;
using PowerLifting.Entity.System.Exercises.Models;

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
        Task<ExerciseDTO> GetExerciseById(int id);

        Task<ExerciseDTO> CreateExercise(CExerciseDTO exercise);

        Task<bool> UpdateExercise(ExerciseDTO exercise);

        Task<bool> DeleteExercise(ExerciseDTO exercise);
    }
}