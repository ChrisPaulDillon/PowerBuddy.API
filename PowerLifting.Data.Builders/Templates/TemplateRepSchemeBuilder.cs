using System;
using System.Collections.Generic;
using System.Text;
using PowerLifting.Data.Entities;

namespace PowerLifting.Data.Builders.Templates
{
    public class TemplateRepSchemeBuilder
    {
        private readonly Random _random;
        private readonly TemplateRepScheme _templateRepScheme;

        public TemplateRepSchemeBuilder(Random random = null)
        {
            _random = random ?? new Random();
            _templateRepScheme = new TemplateRepScheme()
            {
                TemplateRepSchemeId = _random.Next(),
                TemplateExerciseId = _random.Next(),
                Percentage = _random.Next(),
                SetNo = _random.Next(),
                WeightLifted = _random.Next(),
                IsBackOffSet = false,
                AMRAP = false,
                NoOfReps = _random.Next()
            };
        }

        public TemplateRepScheme Build()
        {
            return _templateRepScheme;
        }

        public TemplateRepSchemeBuilder WithTemplateRepSchemeId(int templateRepSchemeId)
        {
            _templateRepScheme.TemplateRepSchemeId = templateRepSchemeId;
            return this;
        }

        public TemplateRepSchemeBuilder WithTemplateExerciseId(int templateExerciseId)
        {
            _templateRepScheme.TemplateExerciseId = templateExerciseId;
            return this;
        }

        public TemplateRepSchemeBuilder WithPercentage(decimal percentage)
        {
            _templateRepScheme.Percentage = percentage;
            return this;
        }

        public TemplateRepSchemeBuilder WithSetNo(int setNo)
        {
            _templateRepScheme.SetNo = setNo;
            return this;
        }

        public TemplateRepSchemeBuilder WithWeightLifted(decimal weight)
        {
            _templateRepScheme.WeightLifted = weight;
            return this;
        }

        public TemplateRepSchemeBuilder WithIsBackOffSet(bool isBackOffSet)
        {
            _templateRepScheme.IsBackOffSet = isBackOffSet;
            return this;
        }

        public TemplateRepSchemeBuilder WithAMRAP(bool amrap)
        {
            _templateRepScheme.AMRAP = amrap;
            return this;
        }
    }
}
