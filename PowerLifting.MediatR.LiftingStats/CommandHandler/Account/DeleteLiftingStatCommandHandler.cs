using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data.Exceptions.Exercises;
using PowerLifting.Data.Exceptions.LiftingStats;
using PowerLifting.MediatR.LiftingStats.Command.Account;
using PowerLifting.Persistence;

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
                .FirstOrDefaultAsync(x => x.ExerciseId == request.LiftingStatId);

            if (liftingStat == null) throw new LiftingStatNotFoundException();

            _context.LiftingStat.Remove(liftingStat);

            var changedRows = await _context.SaveChangesAsync();
            return changedRows > 0;
        }
    }
}
