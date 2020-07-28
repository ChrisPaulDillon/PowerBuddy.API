using PowerLifting.TemplatePrograms.Repository.Contracts;

namespace PowerLifting.TemplatePrograms.Service.Wrapper
{
    public interface ITemplateProgramWrapper
    {
        ITemplateProgramRepository TemplateProgram { get; }
        ITemplateWeekRepository TemplateWeek { get; }
        ITemplateDayRepository TemplateDay { get; }
        ITemplateExerciseRepository TemplateExercise { get; }
        ITemplateRepSchemeRepository TemplateRepScheme { get; }
        ITemplateExerciseCollectionRepository TemplateExerciseCollection { get; }
    }
}