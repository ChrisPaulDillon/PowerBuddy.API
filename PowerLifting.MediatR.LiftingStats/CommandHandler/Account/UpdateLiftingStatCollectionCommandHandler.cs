using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data.DTOs.Exercises;
using PowerLifting.Data.Entities.Exercises;
using PowerLifting.Data.Entities.LiftingStats;
using PowerLifting.MediatR.LiftingStats.Command.Account;
using PowerLifting.Persistence;

namespace PowerLifting.MediatR.LiftingStats.CommandHandler.Account
{
    public class UpdateLiftingStatCollectionCommandHandler : IRequestHandler<UpdateLiftingStatCollectionCommand, bool>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public UpdateLiftingStatCollectionCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateLiftingStatCollectionCommand request, CancellationToken cancellationToken)
        {
            var liftingStatCollection = _mapper.Map<LiftingStat>(request.LiftingStatCollection);
            _context.LiftingStat.Attach(liftingStatCollection);
            var modifiedRows = await _context.SaveChangesAsync();
            return modifiedRows > 0;
        }
    }
}
