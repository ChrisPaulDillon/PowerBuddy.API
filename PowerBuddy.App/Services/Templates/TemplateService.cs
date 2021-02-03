﻿using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Exceptions.TemplatePrograms;
using PowerBuddy.Data.Factories;

namespace PowerBuddy.App.Services.Templates
{
    public class TemplateService : ITemplateService
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly IDTOFactory _dtoFactory;
        private readonly IEntityFactory _entityFactory;

        public TemplateService(PowerLiftingContext context, IMapper mapper, IDTOFactory dtoFactory, IEntityFactory entityFactory)
        {
            _context = context;
            _mapper = mapper;
            _dtoFactory = dtoFactory;
            _entityFactory = entityFactory;
        }

        public async Task<TemplateProgram> GetTemplateProgramById(int templateProgramId)
        {
            var templateProgram = await _context.TemplateProgram
                .Where(x => x.TemplateProgramId == templateProgramId)
                .Include(x => x.TemplateWeeks)
                .ThenInclude(x => x.TemplateDays)
                .ThenInclude(x => x.TemplateExercises)
                .ThenInclude(x => x.TemplateRepSchemes)
                .FirstOrDefaultAsync();

            if (templateProgram == null) throw new TemplateProgramNotFoundException();

            return templateProgram;
        }

        public void AddTemplateProgramAudit(int templateProgramId, string userId, DateTime dateAdded)
        {
            var templateProgramAudit = _entityFactory.CreateTemplateProgramAudit(templateProgramId, userId, dateAdded);
            _context.TemplateProgramAudit.Add(templateProgramAudit);
        }
    }
}