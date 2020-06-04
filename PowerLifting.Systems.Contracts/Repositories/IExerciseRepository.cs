using System.Collections.Generic;
using System.Threading.Tasks;
using Powerlifting.Common;
using PowerLifting.Entity.System.Exercises.Models;

namespace PowerLifting.Systems.Contracts.Repositories
{
    public interface IExerciseRepository : IRepositoryBase<Exercise>
    {
        /// <summary>
        /// Gets all exercises from the database without any dependencies
        /// </summary>
        /// <returns></returns> 
        Task<IEnumerable<Exercise>> GetAllExercises();

        /// <summary>
        /// Gets a specific exercise by id and includes muscle groups and type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Exercise> GetExerciseById(int id);

        /// <summary>
        /// Gets a specific exercise by name and includes muscle groups and type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Exercise> GetExerciseByName(string exerciseName);

        /// <summary>
        /// gets a specific exercise by the exercise type such as barbell, bodyweight etc
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<Exercise>> GetExerciseByExerciseTypeId(int id);

        /// <summary>
        ///     Gets a specific exercise the the exercuse muscle group such as neck, biceps etc
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<Exercise>> GetExerciseByExerciseMuscleGroupId(int id);

        void UpdateExercise(Exercise exercise);
        void DeleteExercise(Exercise exercise);
    }
}