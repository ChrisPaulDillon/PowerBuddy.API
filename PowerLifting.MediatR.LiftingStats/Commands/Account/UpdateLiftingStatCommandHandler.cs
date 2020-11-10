using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data;
using PowerLifting.Data.DTOs.LiftingStats;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.Data.Exceptions.LiftingStats;

namespace PowerLifting.MediatR.LiftingStats.Commands.Account
{
    public class UpdateLiftingStatCommand : IRequest<bool>
    {
        public LiftingStatDTO LiftingStatDTO { get; }
        public string UserId { get; }

        public UpdateLiftingStatCommand(LiftingStatDTO liftingStatDTO, string userId)
        {
            LiftingStatDTO = liftingStatDTO;
            UserId = userId;
        }
    }
    public class UpdateLiftingStatCommandHandler : IRequestHandler<UpdateLiftingStatCommand, bool>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public UpdateLiftingStatCommandHandler(PowerLiftingContext context, IMapper mapper, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<bool> Handle(UpdateLiftingStatCommand request, CancellationToken cancellationToken)
        {
            if(request.UserId != request.LiftingStatDTO.UserId) throw new UnauthorisedUserException();

            var doesLiftingStatExist = await _context.LiftingStat.Where(x => x.LiftingStatId == request.LiftingStatDTO.LiftingStatId)
                .AsNoTracking()
                .AnyAsync(cancellationToken: cancellationToken);

            if (!doesLiftingStatExist) throw new LiftingStatNotFoundException();

            var liftingStatEntity = _mapper.Map<LiftingStat>(request.LiftingStatDTO);
            _context.LiftingStat.Update(liftingStatEntity);

            await _mediator.Send(new CreateLiftingStatAuditCommand(liftingStatEntity.LiftingStatId, liftingStatEntity.ExerciseId, liftingStatEntity.RepRange, (decimal)liftingStatEntity.Weight, liftingStatEntity.UserId, DateTime.UtcNow), cancellationToken);

            var modifiedRows = await _context.SaveChangesAsync(cancellationToken);
            return modifiedRows > 0; 
        }
    }
}
