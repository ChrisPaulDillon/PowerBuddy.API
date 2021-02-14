using System;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.Data.Builders.Templates
{
    public class TemplateExerciseBuilder
    {
        private readonly Random _random;
        private readonly TemplateExercise _templateExercise;

        public TemplateExerciseBuilder(Random random = null)
        {
            _random = random ?? new Random();
            _templateExercise = new TemplateExercise()
            {
                TemplateExerciseId = _random.Next(),
                TemplateDayId = _random.Next(),
                ExerciseId = _random.Next(),
                HasBackOffSets = false,
                BackOffSetFormat = _random.Next().ToString()
            };
        }

        public TemplateExercise Build()
        {
            return _templateExercise;
        }

        public TemplateExerciseBuilder WithTemplateExerciseId(int templateExerciseId)
        {
            _templateExercise.TemplateExerciseId = templateExerciseId;
            return this;
        }

        public TemplateExerciseBuilder WithTemplateDayId(int templateDayId)
        {
            _templateExercise.TemplateDayId = templateDayId;
            return this;
        }

        public TemplateExerciseBuilder WithExerciseId(int exerciseId)
        {
            _templateExercise.ExerciseId = exerciseId;
            return this;
        }

        public TemplateExerciseBuilder WithHasBackOffSet(bool HasBackOffSet)
        {
            _templateExercise.HasBackOffSets = HasBackOffSet;
            return this;
        }

        public TemplateExerciseBuilder WithBackOffSetFormat(string backOffSetFormat)
        {
            _templateExercise.BackOffSetFormat = backOffSetFormat;
            return this;
        }
    }
}
