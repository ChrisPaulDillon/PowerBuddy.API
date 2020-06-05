﻿using PowerLifting.TemplatePrograms.Contracts;
using PowerLifting.TemplatePrograms.Contracts.Repositories;

namespace PowerLifting.TemplatePrograms.Service
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