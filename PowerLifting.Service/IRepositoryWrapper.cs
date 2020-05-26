using PowerLifting.Service.Exercises.Contracts;
using PowerLifting.Service.LiftingStats;
using PowerLifting.Service.LiftingStatsAudit;
using PowerLifting.Service.ProgramLogs.Contracts.Repositories;
using PowerLifting.Service.SystemServices.RepSchemeTypes;
using PowerLifting.Service.SystemServices.TemplateDifficultys;
using PowerLifting.Service.TemplatePrograms.Contracts;
using PowerLifting.Service.TemplatePrograms.Contracts.Repositories;
using PowerLifting.Service.Users;
using PowerLifting.Service.UserSettings;

namespace PowerLifting.Service
{
    public interface IRepositoryWrapper
    {
        ILiftingStatRepository LiftingStat { get; }
        ILiftingStatAuditRepository LiftingStatAudit { get; }
        IExerciseRepository Exercise { get; }
        IExerciseTypeRepository ExerciseType { get; }
        IExerciseMuscleGroupRepository ExerciseMuscleGroup { get; }
        ITemplateDifficultyRepository TemplateDifficulty { get; }
        IRepSchemeTypeRepository RepSchemeRepository { get; }
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
        ITemplateExerciseCollectionRepository TemplateExerciseCollection { get; }
        IUserRepository User { get; }
        IUserSettingRepository UserSetting { get; }
    }
}