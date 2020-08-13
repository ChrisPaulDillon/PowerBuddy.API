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
using PowerLifting.Data.Entities.Exercises;
using PowerLifting.Data.Entities.LiftingStats;
using PowerLifting.Data.Exceptions.LiftingStats;
using PowerLifting.MediatR.LiftingStats.Command.Account;
using PowerLifting.Persistence;

namespace PowerLifting.MediatR.LiftingStats.CommandHandler.Account
{
    public class UpdateLiftingStatCommandHandler : IRequestHandler<UpdateLiftingStatCommand, bool>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public UpdateLiftingStatCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateLiftingStatCommand request, CancellationToken cancellationToken)
        {
            var liftingStat = await _context.LiftingStat.Where(x => x.LiftingStatId == request.LiftingStatDTO.LiftingStatId).AsNoTracking().AnyAsync();
            if (!liftingStat) throw new LiftingStatNotFoundException();

            var liftingStatEntity = _mapper.Map<LiftingStat>(request.LiftingStatDTO);
            _context.Update(liftingStatEntity);

            var liftingStatAudit = new LiftingStatAudit()
            {
                DateChanged = DateTime.UtcNow.Date,
                RepRange = request.LiftingStatDTO.RepRange,
                UserId = request.LiftingStatDTO.UserId,
                ExerciseId = request.LiftingStatDTO.ExerciseId
            };

            _context.Add(liftingStatAudit);

            var modifiedRows = await _context.SaveChangesAsync();

            return modifiedRows > 0; ;
        }
    }
}
