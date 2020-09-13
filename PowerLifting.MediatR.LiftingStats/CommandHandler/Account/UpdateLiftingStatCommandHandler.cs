using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data.DTOs.Exercises;
using PowerLifting.Data.DTOs.LiftingStats;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Entities.Exercises;
using PowerLifting.Data.Entities.LiftingStats;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.Data.Exceptions.LiftingStats;
using PowerLifting.MediatR.LiftingStats.Command.Account;

namespace PowerLifting.MediatR.LiftingStats.CommandHandler.Account
{
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

            await _mediator.Send(new CreateLiftingStatAuditCommand(liftingStatEntity.LiftingStatId, liftingStatEntity.ExerciseId, liftingStatEntity.RepRange, (decimal)liftingStatEntity.Weight, liftingStatEntity.UserId), cancellationToken);

            var modifiedRows = await _context.SaveChangesAsync(cancellationToken);
            return modifiedRows > 0; 
        }
    }
}
