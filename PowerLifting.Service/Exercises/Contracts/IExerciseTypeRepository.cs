using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Service.Exercises.Model;

namespace PowerLifting.Service.Exercises.Contracts
{
    public interface IExerciseTypeRepository : IRepositoryBase<ExerciseType>
    {
        /// <summary>
        /// Gets all exercise types such as bodyweight, dumbbell, barbell etc.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ExerciseType>> GetAllExerciseTypes();

        /// <summary>
        /// Gets a specific exercise type by id
        /// </summary>
        /// <param name="exerciseTypeId"></param>
        /// <returns></returns>
        Task<ExerciseType> GetExerciseTypeById(int exerciseTypeId);

        /// <summary>
        /// Updates a given exercise object
        /// </summary>
        /// <param name="exerciseCategory"></param>
        void UpdateExerciseType(ExerciseType exerciseCategory);

        /// <summary>
        /// Deletes an exercise type object
        /// </summary>
        /// <param name="exerciseCategory"></param>
        void DeleteExerciseType(ExerciseType exerciseCategory);
    }
}