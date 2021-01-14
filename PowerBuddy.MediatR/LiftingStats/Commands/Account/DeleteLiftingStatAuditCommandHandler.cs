﻿using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Exceptions.Account;
using PowerBuddy.Data.Exceptions.LiftingStats;

namespace PowerBuddy.MediatR.LiftingStats.Commands.Account
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
    internal class DeleteLiftingStatAuditCommandHandler : IRequestHandler<DeleteLiftingStatAuditCommand, bool>
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

            _context.LiftingStatAudit.Remove(liftingStatAudit); 
            
            var changedRows = await _context.SaveChangesAsync(cancellationToken);
            return changedRows > 0;
        }
    }
}
