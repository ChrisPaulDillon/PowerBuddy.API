using System;
using PowerLifting.Data.Entities;

namespace PowerLifting.Data.Builders.Templates
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
                TemplateWeekId = _random.Next(),
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

        public TemplateDayBuilder WithTemplateWeekId(int templateWeekId)
        {
            _templateDay.TemplateWeekId = templateWeekId;
            return this;
        }

        public TemplateDayBuilder WithDayNo(int dayNo)
        {
            _templateDay.DayNo = dayNo;
            return this;
        }
    }
}
