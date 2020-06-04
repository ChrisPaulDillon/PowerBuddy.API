using PowerLifting.Systems.Contracts;
using PowerLifting.TemplatePrograms.Contracts;

namespace PowerLifting.Systems.Service
{
    public interface ISystemWrapper
    {
        IExerciseRepository Exercise { get; }
        IExerciseTypeRepository ExerciseType { get; }
        IExerciseMuscleGroupRepository ExerciseMuscleGroup { get; }
        IRepSchemeTypeRepository RepSchemeType { get; }
        ITemplateDifficultyRepository TemplateDifficulty { get; }
    }
}