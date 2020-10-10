using System;
using PowerLifting.Data.Entities;

namespace PowerLifting.Data.Builders.Templates
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
                NoOfSets = _random.Next(),
                RepSchemeFormat = _random.Next().ToString(),
                RepSchemeType = _random.Next().ToString(),
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

        public TemplateExerciseBuilder WithNoOfSets(int noOfSets)
        {
            _templateExercise.NoOfSets = noOfSets;
            return this;
        }

        public TemplateExerciseBuilder WithRepSchemeFormat(string format)
        {
            _templateExercise.RepSchemeFormat = format;
            return this;
        }

        public TemplateExerciseBuilder WithRepSchemeType(string type)
        {
            _templateExercise.RepSchemeType = type;
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
