using PowerLifting.Contracts.Contracts;
using PowerLifting.Service.UserSettings;

namespace PowerLifting.RepositoryMediator
{
    public interface IRepositoryWrapper
    {
        ILiftingStatRepository LiftingStat { get; }
        ILiftingStatAuditRepository LiftingStatAudit { get; }
        IExerciseRepository Exercise { get; }
        IExerciseTypeRepository ExerciseType { get; }
        IExerciseMuscleGroupRepository ExerciseMuscleGroup { get; }
        ITemplateDifficultyRepository TemplateDifficulty { get; }
        IRepSchemeTypeRepository RepSchemeType { get; }
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