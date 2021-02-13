using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Dtos.Templates;
using PowerBuddy.Data.DTOs.Templates;
using PowerBuddy.Data.Factories;

namespace PowerBuddy.App.Services.Templates
{
    public class TemplateService : ITemplateService
    {
        private readonly PowerLiftingContext _context;
        private readonly IEntityFactory _entityFactory;
        private readonly IMapper _mapper;

        public TemplateService(PowerLiftingContext context, IEntityFactory entityFactory, IMapper mapper)
        {
            _context = context;
            _entityFactory = entityFactory;
            _mapper = mapper;
        }

        public async Task<TemplateProgramExtendedDto> GetTemplateProgramById(int templateProgramId)
        {
            var templateProgram = await _context.TemplateProgram
                .Where(x => x.TemplateProgramId == templateProgramId)
                .Include(x => x.TemplateDays)
                .ThenInclude(x => x.TemplateExercises)
                .ThenInclude(x => x.TemplateRepSchemes)
                .FirstOrDefaultAsync();

            var groupedWeeks = templateProgram.TemplateDays.GroupBy(x => x.WeekNo).ToList();

            var templateProgramDto = _mapper.Map<TemplateProgramExtendedDto>(templateProgram);
            var templateWeekList = new List<TemplateWeekDto>();

            foreach (var groupedWeek in groupedWeeks)
            {
                var templateDays = _mapper.Map<IEnumerable<TemplateDayDto>>(groupedWeek.ToList());
                foreach (var templateDay in templateDays)
                {
                    foreach (var templateExercise in templateDay.TemplateExercises)
                    {
                        templateExercise.ExerciseName = await _context.Exercise
                            .AsNoTracking()
                            .Where(x => x.ExerciseId == templateExercise.ExerciseId)
                            .Select(x => x.ExerciseName)
                            .FirstOrDefaultAsync();
                    }
                }
                var week = new TemplateWeekDto()
                {
                    WeekNo = groupedWeek.Key,
                    TemplateDays = templateDays.OrderBy(x => x.DayNo)
                };
                templateWeekList.Add(week);
            }

            templateProgramDto.TemplateWeeks = templateWeekList.OrderBy(x => x.WeekNo);

            return templateProgramDto;
        }

        public void AddTemplateProgramAudit(int templateProgramId, string userId, DateTime dateAdded)
        {
            var templateProgramAudit = _entityFactory.CreateTemplateProgramAudit(templateProgramId, userId, dateAdded);
            _context.TemplateProgramAudit.Add(templateProgramAudit);
        }
    }
}
