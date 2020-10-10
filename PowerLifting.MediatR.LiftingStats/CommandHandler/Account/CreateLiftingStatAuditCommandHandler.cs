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
using PowerLifting.Data.DTOs.LiftingStats;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.MediatR.LiftingStats.Command.Account;

namespace PowerLifting.MediatR.LiftingStats.CommandHandler.Account
{
    public class CreateLiftingStatAuditCommandHandler : IRequestHandler<CreateLiftingStatAuditCommand, Unit>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public CreateLiftingStatAuditCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateLiftingStatAuditCommand request, CancellationToken cancellationToken)
        {
            var liftingStatAudit = new LiftingStatAudit()
            {
                LiftingStatId = request.LiftingStatId,
                ExerciseId = request.ExerciseId,
                RepRange = request.RepRange,
                Weight = request.Weight,
                UserId = request.UserId,
                DateChanged = DateTime.UtcNow
            };

            _context.LiftingStatAudit.Add(liftingStatAudit);

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
