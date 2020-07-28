using System.Threading.Tasks;
using AutoMapper;
using PowerLifting.Data.Entities.Account;
using PowerLifting.LiftingStats.Contracts;
using PowerLifting.Persistence;

namespace PowerLifting.LiftingStats.Repository
{
    public class LiftingStatAuditRepository : ILiftingStatAuditRepository
    {
        private readonly PowerliftingContext _context;
        private readonly IMapper _mapper;

        public LiftingStatAuditRepository(PowerliftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> CreateLiftingStatAudit(LiftingStatAudit liftingStatAudit)
        {
            _context.Add(liftingStatAudit);
            await _context.SaveChangesAsync();
            return liftingStatAudit.LiftingStatAuditId;
        }
    }
}
