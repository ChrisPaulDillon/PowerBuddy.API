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
using PowerLifting.MediatR.LiftingStats.Command.Account;

namespace PowerLifting.MediatR.LiftingStats.CommandHandler.Account
{
    public class CreateLiftingStatCollectionCommandHandler : IRequestHandler<CreateLiftingStatCollectionCommand, bool>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public CreateLiftingStatCollectionCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateLiftingStatCollectionCommand request, CancellationToken cancellationToken)
        {
            if(request.LiftingStatCollection.ToList()[0].UserId != request.UserId) throw new UnauthorisedUserException();

            var liftingStatsToAdd = new List<LiftingStatDTO>();
            var liftingStatsToUpdate = new List<LiftingStat>();
            foreach (var liftingStat in request.LiftingStatCollection.ToList())
            {
                liftingStat.Exercise = null;
                var liftingStatEntity = await _context.LiftingStat
                    .FirstOrDefaultAsync(x => x.UserId == request.UserId && x.RepRange == liftingStat.RepRange && x.ExerciseId == liftingStat.ExerciseId, cancellationToken: cancellationToken);
                if (liftingStatEntity != null)
                {
                    liftingStatEntity.Weight = liftingStat.Weight;
                    liftingStatsToUpdate.Add(liftingStatEntity);
                }
                else
                {
                    liftingStatsToAdd.Add(liftingStat);
                }
            }

            var liftingStatEntitiesToAdd = _mapper.Map<IEnumerable<LiftingStat>>(liftingStatsToAdd);

            _context.LiftingStat.UpdateRange(liftingStatsToUpdate);
            _context.LiftingStat.AddRange(liftingStatEntitiesToAdd);

            var modifiedRows = await _context.SaveChangesAsync(cancellationToken);
            return modifiedRows > 0;
        }
    }
}
