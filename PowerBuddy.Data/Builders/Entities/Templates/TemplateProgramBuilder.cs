﻿using System;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.Data.Builders.Templates
{
    public class TemplateProgramBuilder
    {
        private readonly Random _random;
        private readonly TemplateProgram _templateProgram;

        public TemplateProgramBuilder(Random random = null)
        {
            _random = random ?? new Random();
            _templateProgram = new TemplateProgram()
            {
                TemplateProgramId = _random.Next(),
                Name = _random.Next().ToString(),
                Difficulty = _random.Next().ToString(),
                NoOfDaysPerWeek = _random.Next(),
                TemplateType = _random.Next().ToString(),
                WeightProgressionType = _random.Next().ToString(),
            };
        }

        public TemplateProgram Build()
        {
            return _templateProgram;
        }
        public TemplateProgramBuilder WithTemplateProgramId(int templateProgramId)
        {
            _templateProgram.TemplateProgramId = templateProgramId;
            return this;
        }

        public TemplateProgramBuilder WithName(string name)
        {
            _templateProgram.Name = name;
            return this;
        }

        public TemplateProgramBuilder WithDifficulty(string difficulty)
        {
            _templateProgram.Difficulty = difficulty;
            return this;
        }

        public TemplateProgramBuilder WithNoOfDaysPerWeek(int noOfDaysPerWeek)
        {
            _templateProgram.NoOfDaysPerWeek = noOfDaysPerWeek;
            return this;
        }

        public TemplateProgramBuilder WithWeightProgressionType(string type)
        {
            _templateProgram.WeightProgressionType = type;
            return this;
        }
    }
}
