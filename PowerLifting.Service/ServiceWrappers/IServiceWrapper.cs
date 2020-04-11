using Powerlifting.Service.LiftingStats;
using PowerLifting.Service.Users;
using Powerlifting.Services.ProgramLogs;
using Powerlifting.Services.TemplatePrograms;
using PowerLifting.Service.LiftingStatsAudit;
using PowerLifting.Services.ProgramLogRepSchemes;
using PowerLifting.Service.Exercises.Contracts;
using Powerlifting.Service.Exercises.Contracts;
using PowerLifting.Service.ProgramLogExercises;
using PowerLifting.Service.TemplateExercises;
using Powerlifting.Service.TemplateRepSchemes;

namespace PowerLifting.Service.ServiceWrappers
{
    public interface IServiceWrapper
    {
        IUserService User { get; }
        ILiftingStatService LiftingStat { get; }
        ILiftingStatAuditService LiftingStatAudit{ get; }
        IExerciseService Exercise { get; }
        IExerciseTypeService ExerciseType { get; }
        IExerciseMuscleGroupService ExerciseMuscleGroup { get; }
        IProgramLogService ProgramLog { get; }
        IProgramLogExerciseService ProgramLogExercise { get; }
        IProgramLogRepSchemeService ProgramLogRepScheme { get; }
        ITemplateProgramService TemplateProgram { get; }
        ITemplateExerciseService TemplateExercise { get; }
        ITemplateRepSchemeService TemplateRepScheme { get; }
    }
}
