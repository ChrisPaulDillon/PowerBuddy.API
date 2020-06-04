using PowerLifting.Contracts.Contracts;
using PowerLifting.ProgramLogs.Contracts;
using PowerLifting.Service.LiftingStats;
using PowerLifting.Service.SystemServices.TemplateDifficultys;
using PowerLifting.Service.TemplatePrograms.Contracts.Services;

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
        ITemplateProgramService TemplateProgram { get; }
        IUserService User { get; }
        IUserSettingService UserSetting { get; }
    }
}