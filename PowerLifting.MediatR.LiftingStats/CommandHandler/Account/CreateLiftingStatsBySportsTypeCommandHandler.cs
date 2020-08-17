using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Entities.LiftingStats;
using PowerLifting.MediatR.LiftingStats.Command.Account;

namespace PowerLifting.MediatR.LiftingStats.CommandHandler.Account
{
    public class CreateLiftingStatsBySportsTypeCommandHandler : IRequestHandler<CreateLiftingStatsBySportsTypeCommand, bool>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public CreateLiftingStatsBySportsTypeCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateLiftingStatsBySportsTypeCommand request, CancellationToken cancellationToken)
        {
            var repRanges = new int[] { 1, 2, 3, 5, 10 };
            var exerciseList = request.Exercises.ToList();
            foreach (var exercise in exerciseList)
            {
                foreach (var repRange in repRanges)
                {
                    _context.Add(
                        new LiftingStat()
                        {
                            UserId = request.UserId,
                            ExerciseId = exercise.ExerciseId,
                            RepRange = repRange,
                            LastUpdated = DateTime.UtcNow
                        });
                }
            }

            var modifiedRows = await _context.SaveChangesAsync();
            return modifiedRows > 0; ;
        }
    }
}
