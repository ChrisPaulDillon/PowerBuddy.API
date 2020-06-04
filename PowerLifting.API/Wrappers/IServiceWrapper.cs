using PowerLifting.ProgramLogs.Contracts;
using PowerLifting.Service.Exercises.Contracts;
using PowerLifting.Service.LiftingStats;
using PowerLifting.Service.SystemServices.RepSchemeTypes;
using PowerLifting.Service.SystemServices.TemplateDifficultys;
using PowerLifting.Service.TemplatePrograms.Contracts.Services;
using PowerLifting.Service.Users;
using PowerLifting.Service.UserSettings;

namespace PowerLifting.Service
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