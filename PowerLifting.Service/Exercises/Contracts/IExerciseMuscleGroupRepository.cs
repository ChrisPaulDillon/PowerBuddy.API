using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Service.Exercises.Model;

namespace PowerLifting.Service.Exercises.Contracts
{
    public interface IExerciseMuscleGroupRepository : IRepositoryBase<ExerciseMuscleGroup>
    {
        /// <summary>
        ///     Gets all muscle groups such as quads, shoulders, arms etc.
        /// </summary>
        /// <returns></returns>
        IEnumerable<ExerciseMuscleGroup> GetAllExerciseMuscleGroups();

        /// <summary>
        ///     Get a specific exercise muscle group by id
        /// </summary>
        /// <param name="exerciseTypeId"></param>
        /// <returns></returns>
        Task<ExerciseMuscleGroup> GetExerciseMuscleGroupById(int exerciseMuscleGroupId);

        /// <summary>
        ///     Updates a specific muscle group object
        /// </summary>
        /// <param name="exerciseMuscleGroup"></param>
        void UpdateExerciseMuscleGroup(ExerciseMuscleGroup exerciseMuscleGroup);

        /// <summary>
        ///     Deletes a specific muscle group object
        /// </summary>
        /// <param name="exerciseMuscleGroup"></param>
        void DeleteExerciseMuscleGroup(ExerciseMuscleGroup exerciseMuscleGroup);
    }
}