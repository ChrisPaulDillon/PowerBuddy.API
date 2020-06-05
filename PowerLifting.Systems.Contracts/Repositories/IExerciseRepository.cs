using System.Collections.Generic;
using System.Threading.Tasks;
using Powerlifting.Common;
using PowerLifting.Entity.System.Exercises.DTOs;
using PowerLifting.Entity.System.Exercises.Models;

namespace PowerLifting.Systems.Contracts.Repositories
{
    public interface IExerciseRepository : IRepositoryBase<Exercise>
    {
        /// <summary>
        /// Gets all exercises from the database without any dependencies
        /// </summary>
        /// <returns></returns> 
        Task<IEnumerable<ExerciseDTO>> GetAllExercises();

        /// <summary>
        /// Gets a specific exercise by id and includes muscle groups and type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ExerciseDTO> GetExerciseById(int id);

        /// <summary>
        /// Gets a specific exercise by id and includes muscle groups and type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DoesExerciseExist(int id);

        /// <summary>
        /// Gets a specific exercise by name and includes muscle groups and type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ExerciseDTO> GetExerciseByName(string exerciseName);

        void UpdateExercise(Exercise exercise);
        void DeleteExercise(Exercise exercise);
    }
}