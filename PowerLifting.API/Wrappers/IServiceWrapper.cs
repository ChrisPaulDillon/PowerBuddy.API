using PowerLifting.Accounts.Contracts;
using PowerLifting.LiftingStats.Service;
using PowerLifting.ProgramLogs.Contracts;
using PowerLifting.Service.SystemServices.TemplateDifficultys;
using PowerLifting.Systems.Contracts;
using PowerLifting.TemplatePrograms.Contracts;

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
        ITemplateExerciseCollectionService TemplateExerciseCollection { get; }
        IUserService User { get; }
        IUserSettingService UserSetting { get; }
    }
}