﻿using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PowerLifting.Data;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.MediatR.LiftingStats.Command.Account;

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
            if(request.LiftingStatCollection.ToList()[0].UserId != request.UserId) throw new UnauthorisedUserException();

            var liftingStatCollection = _mapper.Map<LiftingStat>(request.LiftingStatCollection);
            _context.LiftingStat.Attach(liftingStatCollection);
            var modifiedRows = await _context.SaveChangesAsync(cancellationToken);
            return modifiedRows > 0;
        }
    }
}
