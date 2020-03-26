﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Powerlifting.Repository;
using Powerlifting.Services.ProgramTemplates;
using PowerLifting.Persistence;
using PowerLifting.Services.ProgramTemplates;

namespace PowerLifting.Repository.Repositories
{
    public class ProgramTemplateRepository : RepositoryBase<ProgramTemplate>, IProgramTemplateRepository
    {
        public ProgramTemplateRepository(PowerliftingContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ProgramTemplate>> GetAllProgramTemplates()
        {
            return await PowerliftingContext.Set<ProgramTemplate>().Include(x => x.ProgramExercises).ThenInclude(s => s.IndividualSets).ToListAsync();
        }

        public async Task<ProgramTemplate> GetProgramTemplateById(int programTemplateId)
        {
            return await PowerliftingContext.Set<ProgramTemplate>().Where(x => x.ProgramTemplateId == programTemplateId).FirstOrDefaultAsync();
        }

        public async Task<ProgramTemplate> GetProgramTemplateByName(string programType)
        {
            return await PowerliftingContext.Set<ProgramTemplate>().Where(x => x.Name == programName).FirstOrDefaultAsync();
        }

        public Task<ProgramTemplate> CreateProgramTemplate(ProgramTemplate programType)
        {
            throw new System.NotImplementedException();
        }

      
    }
}
