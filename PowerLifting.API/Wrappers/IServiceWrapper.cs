using PowerLifting.Accounts.Contracts.Services;
using PowerLifting.LiftingStats.Service;
using PowerLifting.ProgramLogs.Contracts.Services;
using PowerLifting.Systems.Contracts.Services;
using PowerLifting.TemplatePrograms.Contracts.Services;

namespace PowerLifting.API.Wrappers
{
    public interface IServiceWrapper
    {
        ILiftingStatService LiftingStat { get; }
        IExerciseService Exercise { get; }
        IExerciseTypeService ExerciseType { get; }
        ITemplateDifficultyService TemplateDifficulty { get; }
        IRepSchemeTypeService RepSchemeType { get; }
        IExerciseMuscleGroupService ExerciseMuscleGroup { get; }
        IProgramLogService ProgramLog { get; }
        IProgramLogRepSchemeService ProgramLogRepScheme { get; }
        IProgramLogExerciseService ProgramLogExercise { get; }
        ITemplateProgramService TemplateProgram { get; }
        ITemplateExerciseCollectionService TemplateExerciseCollection { get; }
        IUserService User { get; }
        IUserSettingService UserSetting { get; }
    }
}