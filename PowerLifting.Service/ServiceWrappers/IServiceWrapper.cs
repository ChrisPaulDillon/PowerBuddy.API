using Powerlifting.Service.ExerciseCategories;
using Powerlifting.Service.Exercises;
using Powerlifting.Service.LiftingStats;
using PowerLifting.Service.Users;
using Powerlifting.Services.ProgramLogs;
using Powerlifting.Services.TemplatePrograms;
using PowerLifting.Service.LiftingStatsAudit;
using PowerLifting.Services.ProgramLogExercises;
using PowerLifting.Services.ProgramLogRepSchemes;
using PowerLifting.Services.TemplateExercises;
using Powerlifting.Services.TemplateRepSchemes;

namespace PowerLifting.Service.ServiceWrappers
{
    public interface IServiceWrapper
    {
        IUserService User { get; }
        ILiftingStatService LiftingStat { get; }
        ILiftingStatAuditService LiftingStatAudit{ get; }
        IExerciseService Exercise { get; }
        IExerciseCategoryService ExerciseCategory { get; }
        IProgramLogService ProgramLog { get; }
        IProgramLogExerciseService ProgramLogExercise { get; }
        IProgramLogRepSchemeService ProgramLogRepScheme { get; }
        ITemplateProgramService TemplateProgram { get; }
        ITemplateExerciseService TemplateExercise { get; }
        ITemplateRepSchemeService TemplateRepScheme { get; }
    }
}
