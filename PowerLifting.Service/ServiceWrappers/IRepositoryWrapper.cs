using PowerLifting.Service.LiftingStatsAudit;
using PowerLifting.Service.Users;
using PowerLifting.Services.ExerciseCategories;
using PowerLifting.Services.Exercises;
using PowerLifting.Services.LiftingStats;
using PowerLifting.Services.ProgramLogExercises;
using PowerLifting.Services.ProgramLogRepSchemes;
using PowerLifting.Services.ProgramLogs;
using PowerLifting.Services.TemplateExercises;
using PowerLifting.Services.TemplatePrograms;
using PowerLifting.Services.TemplateRepSchemes;

namespace PowerLifting.Service.ServiceWrappers
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        ILiftingStatRepository LiftingStat { get; }
        ILiftingStatAuditRepository LiftingStatAudit { get; }
        IExerciseRepository Exercise { get; }
        IExerciseCategoryRepository ExerciseCategory { get; }
        IProgramLogRepository ProgramLog { get; }
        IProgramLogExerciseRepository ProgramLogExercise { get; }
        IProgramLogRepSchemeRepository ProgramLogRepScheme { get; }
        ITemplateProgramRepository TemplateProgram { get; }
        ITemplateExerciseRepository TemplateExercise { get; }
        ITemplateRepSchemeRepository TemplateRepScheme { get; }
    }
}
