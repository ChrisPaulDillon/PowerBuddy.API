﻿using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.Data.Exceptions.LiftingStats;

namespace PowerLifting.MediatR.LiftingStats.Commands.Account
{
    public class DeleteLiftingStatCommand : IRequest<bool>
    {
        public int LiftingStatId { get; }
        public string UserId { get; }

        public DeleteLiftingStatCommand(int liftingStatId, string userId)
        {
            LiftingStatId = liftingStatId;
            UserId = userId;
        }
    }
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
            var liftingStat = await _context.LiftingStat.FirstOrDefaultAsync(x => x.LiftingStatId == request.LiftingStatId && x.UserId == request.UserId, cancellationToken: cancellationToken);

            if (liftingStat == null) throw new LiftingStatNotFoundException();

            if(liftingStat.UserId != request.UserId) throw new UnauthorisedUserException();

            _context.LiftingStat.Remove(liftingStat);

            var changedRows = await _context.SaveChangesAsync(cancellationToken);
            return changedRows > 0;
        }
    }
}
