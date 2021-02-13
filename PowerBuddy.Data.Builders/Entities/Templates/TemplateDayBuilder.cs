using System;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.Data.Builders.Templates
{
    public class TemplateDayBuilder
    {
        private readonly Random _random;
        private readonly TemplateDay _templateDay;

        public TemplateDayBuilder(Random random = null)
        {
            _random = random ?? new Random();
            _templateDay = new TemplateDay()
            {
                TemplateDayId = _random.Next(),
                TemplateProgramId = _random.Next(),
                WeekNo = _random.Next(),
                DayNo = _random.Next(),
            };
        }

        public TemplateDay Build()
        {
            return _templateDay;
        }

        public TemplateDayBuilder WithTemplateDayId(int templateDayId)
        {
            _templateDay.TemplateDayId = templateDayId;
            return this;
        }

        public TemplateDayBuilder WithTemplateProgramId(int templateProgramId)
        {
            _templateDay.TemplateProgramId = templateProgramId;
            return this;
        }

        public TemplateDayBuilder WithWeekNo(int weekNo)
        {
            _templateDay.WeekNo = weekNo;
            return this;
        }

        public TemplateDayBuilder WithDayNo(int dayNo)
        {
            _templateDay.DayNo = dayNo;
            return this;
        }
    }
}
