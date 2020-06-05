using System.Collections.Generic;
using System.Threading.Tasks;
using Powerlifting.Common;
using PowerLifting.Entity.System.ExerciseTypes.DTOs;
using PowerLifting.Entity.System.ExerciseTypes.Models;

namespace PowerLifting.Systems.Contracts.Repositories
{
    public interface IExerciseTypeRepository : IRepositoryBase<ExerciseType>
    {
        /// <summary>
        /// Gets all exercise types such as bodyweight, dumbbell, barbell etc.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ExerciseTypeDTO>> GetAllExerciseTypes();

        /// <summary>
        /// Gets a specific exercise type by id
        /// </summary>
        /// <param name="exerciseTypeId"></param>
        /// <returns></returns>
        Task<ExerciseTypeDTO> GetExerciseTypeById(int exerciseTypeId);

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