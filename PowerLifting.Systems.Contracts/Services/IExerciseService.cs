using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Data.DTOs.System;
using PowerLifting.Data.Entities.System;

namespace PowerLifting.Systems.Contracts.Services
{
    public interface IExerciseService
    {
        /// <summary>
        /// Gets a overview of all exercises available
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ExerciseDTO>> GetAllExercises();

        /// <summary>
        /// Gets all exercises under a given sport title
        /// </summary>
        Task<IEnumerable<TopLevelExerciseDTO>> GetAllExercisesBySport(string exerciseSport);

        /// <summary>
        /// Gets a specific exercise by id and includes its type and muscle groups worked
        /// </summary>
        Task<Exercise> GetExerciseById(int id);

        Task<Exercise> CreateExercise(CExerciseDTO exercise);

        Task<bool> UpdateExercise(ExerciseDTO exercise);

        Task<bool> DeleteExercise(ExerciseDTO exercise);
    }
}