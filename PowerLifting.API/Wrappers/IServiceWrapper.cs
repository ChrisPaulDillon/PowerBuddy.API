using PowerLifting.Accounts.Service;
using PowerLifting.Exercises.Service;
using PowerLifting.LiftingStats.Service;
using PowerLifting.ProgramLogs.Service;
using PowerLifting.Systems.Service;
using PowerLifting.TemplatePrograms.Service;

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
        IQuoteService Quote { get; }

        IProgramLogService ProgramLog { get; }
        IProgramLogDayService ProgramLogDay { get; }
        IProgramLogRepSchemeService ProgramLogRepScheme { get; }
        IProgramLogExerciseService ProgramLogExercise { get; }
        ITemplateProgramService TemplateProgram { get; }
        ITemplateExerciseCollectionService TemplateExerciseCollection { get; }

        IUserService User { get; }
        IUserSettingService UserSetting { get; }
        INotificationService Notification { get; }
        IFriendsListService FriendsList { get; }
    }
}