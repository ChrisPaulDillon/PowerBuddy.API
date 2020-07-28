using PowerLifting.Exercises.Repository;

namespace PowerLifting.Exercises.Service.Wrapper
{
    public interface IExerciseWrapper
    {
        IExerciseTypeRepository ExerciseType { get; }
        IExerciseMuscleGroupRepository ExerciseMuscleGroup { get; }
    }
}