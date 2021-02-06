using System.Collections.Generic;
using System.Threading.Tasks;
using PowerBuddy.Data.Dtos.Exercises;

namespace PowerBuddy.App.Repositories.Exercises
{
    public interface IExerciseRepository
    {
        public Task<IEnumerable<ExerciseDto>> GetAllExercises();

        public Task<IEnumerable<ExerciseMuscleGroupDto>> GetAllExerciseMuscleGroups();

        public Task<IEnumerable<ExerciseTypeDto>> GetAllExerciseTypes();
    }
}
