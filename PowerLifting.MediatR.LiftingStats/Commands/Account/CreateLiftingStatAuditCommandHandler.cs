using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PowerLifting.Data;
using PowerLifting.Data.Entities;

namespace PowerLifting.MediatR.LiftingStats.Commands.Account
{
    public class CreateLiftingStatAuditCommand : IRequest<Unit>
    {
        public int LiftingStatId { get; }
        public int ExerciseId { get; }
        public int RepRange { get; }
        public decimal Weight { get; }
        public string UserId { get; }
        public DateTime Date { get; set; }

        public CreateLiftingStatAuditCommand(int liftingStatId, int exerciseId, int repRange, decimal weight, string userId, DateTime date)
        {
            LiftingStatId = liftingStatId;
            ExerciseId = exerciseId;
            RepRange = repRange;
            Weight = weight;
            UserId = userId;
            Date = date;
        }
    }

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
                DateChanged = request.Date
            };

            _context.LiftingStatAudit.Add(liftingStatAudit);

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
