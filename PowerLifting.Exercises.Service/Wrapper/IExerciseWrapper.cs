using PowerLifting.Exercises.Repository;

namespace PowerLifting.Exercises.Service.Wrapper
{
    public interface IExerciseWrapper
    {
        IExerciseRepository Exercise { get; }
        IExerciseTypeRepository ExerciseType { get; }
        IExerciseMuscleGroupRepository ExerciseMuscleGroup { get; }
    }
}