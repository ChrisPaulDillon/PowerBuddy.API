using Powerlifting.Service.ExerciseCategories;
using Powerlifting.Service.Exercises;
using Powerlifting.Service.LiftingStats;
using PowerLifting.Service.Users;
using Powerlifting.Services.ProgramLogs;
using Powerlifting.Services.TemplatePrograms;
using PowerLifting.Services.Users;

namespace PowerLifting.Service.ServiceWrappers
{
    public interface IServiceWrapper
    {
        IUserService User { get; }
        ILiftingStatService LiftingStat { get; }
        IExerciseService Exercise { get; }
        IExerciseCategoryService ExerciseCategory { get; }
        IProgramLogService ProgramLog { get; }
        ITemplateProgramService TemplateProgram { get; }
    }
}
