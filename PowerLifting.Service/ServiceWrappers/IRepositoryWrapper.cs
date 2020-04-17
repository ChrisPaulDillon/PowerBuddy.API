using PowerLifting.Service.Exercises.Contracts;
using PowerLifting.Service.LiftingStats;
using PowerLifting.Service.LiftingStatsAudit;
using PowerLifting.Service.ProgramLogs.Contracts.Repositories;
using PowerLifting.Service.TemplatePrograms.Contracts.Repositories;
using PowerLifting.Service.Users;

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
        IProgramLogWeekRepository ProgramLogWeek { get; }
        IProgramLogDayRepository ProgramLogDay { get; }
        IProgramLogExerciseRepository ProgramLogExercise { get; }
        IProgramLogRepSchemeRepository ProgramLogRepScheme { get; }
        ITemplateProgramRepository TemplateProgram { get; }
        ITemplateWeekRepository TemplateWeek { get; }
        ITemplateDayRepository TemplateDay { get; }
        ITemplateExerciseRepository TemplateExercise { get; }
        ITemplateRepSchemeRepository TemplateRepScheme { get; }
    }
}