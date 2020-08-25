using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.Data.Exceptions.Exercises;
using PowerLifting.Data.Exceptions.LiftingStats;
using PowerLifting.MediatR.LiftingStats.Command.Account;

namespace PowerLifting.MediatR.LiftingStats.CommandHandler.Account
{
    public class DeleteLiftingStatCommandHandler : IRequestHandler<DeleteLiftingStatCommand, bool>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public DeleteLiftingStatCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteLiftingStatCommand request, CancellationToken cancellationToken)
        {
            var liftingStat = await _context.LiftingStat
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ExerciseId == request.LiftingStatId, cancellationToken: cancellationToken);

            if (liftingStat == null) throw new LiftingStatNotFoundException();

            if(liftingStat.UserId != request.UserId) throw new UnauthorisedUserException();

            _context.LiftingStat.Remove(liftingStat);

            var changedRows = await _context.SaveChangesAsync(cancellationToken);
            return changedRows > 0;
        }
    }
}
