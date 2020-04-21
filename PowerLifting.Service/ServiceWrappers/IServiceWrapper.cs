using PowerLifting.Service.Exercises.Contracts;
using PowerLifting.Service.LiftingStats;
using PowerLifting.Service.LiftingStatsAudit;
using PowerLifting.Service.ProgramLogs.Contracts.Services;
using PowerLifting.Service.TemplatePrograms.Contracts.Services;
using PowerLifting.Service.Users;

namespace PowerLifting.Service.ServiceWrappers
{
    public interface IServiceWrapper
    {
        IUserService User { get; }
        ILiftingStatService LiftingStat { get; }
        IExerciseService Exercise { get; }
        IExerciseTypeService ExerciseType { get; }
        IExerciseMuscleGroupService ExerciseMuscleGroup { get; }
        IProgramLogService ProgramLog { get; }
        ITemplateProgramService TemplateProgram { get; }
    }
}