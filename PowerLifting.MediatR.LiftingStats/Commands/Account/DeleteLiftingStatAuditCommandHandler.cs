using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.Data.Exceptions.LiftingStats;

namespace PowerLifting.MediatR.LiftingStats.Commands.Account
{
    public class DeleteLiftingStatAuditCommand : IRequest<bool>
    {
        public int LiftingStatAuditId { get; }
        public string UserId { get; }

        public DeleteLiftingStatAuditCommand(int liftingStatAuditId, string userId)
        {
            LiftingStatAuditId = liftingStatAuditId;
            UserId = userId;
        }
    }
    public class DeleteLiftingStatAuditCommandHandler : IRequestHandler<DeleteLiftingStatAuditCommand, bool>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public DeleteLiftingStatAuditCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteLiftingStatAuditCommand request, CancellationToken cancellationToken)
        {
            var liftingStatAudit = await _context.LiftingStatAudit
                .FirstOrDefaultAsync(x => x.LiftingStatAuditId == request.LiftingStatAuditId && x.UserId == request.UserId, cancellationToken: cancellationToken);

            if (liftingStatAudit == null) throw new LiftingStatNotFoundException();
            if (liftingStatAudit.UserId != request.UserId) throw new UnauthorisedUserException();

            //Check if the current lifting stat being deleted is the users current personal best
            var liftingStat = await _context.LiftingStat 
                .FirstOrDefaultAsync(x =>
                    x.ExerciseId == liftingStatAudit.ExerciseId && 
                    x.RepRange == liftingStatAudit.RepRange && 
                    x.Weight == liftingStatAudit.Weight);

            if (liftingStat != null)
            {
                var liftingStatAudits = await _context.LiftingStatAudit
                    .AsNoTracking()
                    .Where(x => x.ExerciseId == liftingStatAudit.ExerciseId && x.RepRange == liftingStatAudit.RepRange && x.UserId == request.UserId)
                    .OrderByDescending(x => x.Weight)
                    .ToListAsync(cancellationToken: cancellationToken);

                if (liftingStatAudits.Count > 1) //There is an audit entry the personal best can be rolled back to
                {
                    liftingStat.Weight = liftingStatAudits[1].Weight; //Update weight to previous PB
                }
                else //This was the only personal best for the user, delete it & the audit trail
                {
                    _context.LiftingStat.Remove(liftingStat);
                }
            }

            _context.LiftingStatAudit.Remove(liftingStatAudit); 
            
            var changedRows = await _context.SaveChangesAsync(cancellationToken);
            return changedRows > 0;
        }
    }
}
