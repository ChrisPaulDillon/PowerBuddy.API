using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data.Entities.Account;
using PowerLifting.Data.Entities.LiftingStats;
using PowerLifting.Data.Entities.Templates;
using PowerLifting.Persistence;

namespace PowerLifting.TemplatePrograms.Service
{
    public class TemplateExerciseCollectionService : ITemplateExerciseCollectionService
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public TemplateExerciseCollectionService(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<int> GetTemplateExerciseCollectionByTemplateProgramId(int templateProgramId)
        {
          
        }

        public async Task<IEnumerable<int>> DoesUserHaveExerciseCollection1RMSet(int templateProgramId, string userId)
        {
          
        }
    }
}