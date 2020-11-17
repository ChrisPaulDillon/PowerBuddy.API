using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PowerBuddy.Context;
using PowerBuddy.Data.DTOs.LiftingStats;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Exceptions.Account;

namespace PowerBuddy.MediatR.LiftingStats.Commands.Account
{
    public class UpdateLiftingStatCollectionCommand : IRequest<bool>
    {
        public IEnumerable<LiftingStatDTO> LiftingStatCollection { get; }
        public string UserId { get; }

        public UpdateLiftingStatCollectionCommand(IEnumerable<LiftingStatDTO> liftingStatCollection, string userId)
        {
            LiftingStatCollection = liftingStatCollection;
            UserId = userId;
        }
    }

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
