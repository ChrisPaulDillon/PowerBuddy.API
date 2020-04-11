using PowerLifting.Service.Exercises.Contracts;
using PowerLifting.Service.LiftingStats;
using PowerLifting.Service.LiftingStatsAudit;
using PowerLifting.Service.ProgramLogExercises;
using PowerLifting.Service.ProgramLogRepSchemes;
using PowerLifting.Service.TemplateExercises;
using PowerLifting.Service.TemplatePrograms;
using PowerLifting.Service.TemplateRepSchemes;
using PowerLifting.Service.Users;
using PowerLifting.Services.ProgramLogs;

namespace PowerLifting.Service.ServiceWrappers
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        ILiftingStatRepository LiftingStat { get; }
        ILiftingStatAuditRepository LiftingStatAudit { get; }
        IExerciseRepository Exercise { get; }
        IExerciseTypeRepository ExerciseType { get; }
        IExerciseMuscleGroupRepository ExerciseMuscleGroup { get; }
        IProgramLogRepository ProgramLog { get; }
        IProgramLogExerciseRepository ProgramLogExercise { get; }
        IProgramLogRepSchemeRepository ProgramLogRepScheme { get; }
        ITemplateProgramRepository TemplateProgram { get; }
        ITemplateExerciseRepository TemplateExercise { get; }
        ITemplateRepSchemeRepository TemplateRepScheme { get; }
    }
}
