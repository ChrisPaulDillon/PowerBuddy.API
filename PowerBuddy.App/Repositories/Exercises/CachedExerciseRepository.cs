using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using PowerBuddy.Data.DTOs.Exercises;

namespace PowerBuddy.App.Repositories.Exercises
{
    public class CachedExerciseRepository : IExerciseRepository
    {
        private readonly IExerciseRepository _exerciseRepo;

        private static readonly ConcurrentDictionary<int, ExerciseDTO> _cachedExercises = new ConcurrentDictionary<int, ExerciseDTO>();
        private static readonly ConcurrentDictionary<int, ExerciseMuscleGroupDTO> _cachedExerciseMuscleGroups = new ConcurrentDictionary<int, ExerciseMuscleGroupDTO>();
        private static readonly ConcurrentDictionary<int, ExerciseTypeDTO> _cachedExerciseTypes = new ConcurrentDictionary<int, ExerciseTypeDTO>();

        public CachedExerciseRepository(IExerciseRepository exerciseRepo)
        {
            _exerciseRepo = exerciseRepo;
        }

        public async Task<IEnumerable<ExerciseDTO>> GetAllExercises()
        {
            if (!_cachedExercises.IsEmpty)
            {
                return _cachedExercises.Values;
            }

            var exercises = await _exerciseRepo.GetAllExercises();
            foreach (var exercise in exercises)
            {
                _cachedExercises.TryAdd(exercise.ExerciseId, exercise);
            }

            return _cachedExercises.Values;
        }

        public async Task<IEnumerable<ExerciseMuscleGroupDTO>> GetAllExerciseMuscleGroups()
        {
            if (!_cachedExerciseMuscleGroups.IsEmpty)
            {
                return _cachedExerciseMuscleGroups.Values;
            }

            var exercises = await _exerciseRepo.GetAllExerciseMuscleGroups();
            foreach (var exercise in exercises)
            {
                _cachedExerciseMuscleGroups.TryAdd(exercise.ExerciseMuscleGroupId, exercise);
            }

            return _cachedExerciseMuscleGroups.Values;
        }

        public async Task<IEnumerable<ExerciseTypeDTO>> GetAllExerciseTypes()
        {
            if (!_cachedExerciseTypes.IsEmpty)
            {
                return _cachedExerciseTypes.Values;
            }

            var exercises = await _exerciseRepo.GetAllExerciseTypes();
            foreach (var exercise in exercises)
            {
                _cachedExerciseTypes.TryAdd(exercise.ExerciseTypeId, exercise);
            }

            return _cachedExerciseTypes.Values;
        }
    }
}
