using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data.Exceptions.Exercises;
using PowerLifting.MediatR.Exercises.Command.Admin;
using PowerLifting.Persistence;

namespace PowerLifting.MediatR.Exercises.CommandHandler.Admin
{
    public class DeleteExerciseCommandHandler : IRequestHandler<DeleteExerciseCommand, bool>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public DeleteExerciseCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteExerciseCommand request, CancellationToken cancellationToken)
        {
            var exercise = await _context.Exercise
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ExerciseId == request.ExerciseId);

            if (exercise == null) throw new ExerciseNotFoundException();

            _context.Remove(exercise);

            var changedRows = await _context.SaveChangesAsync();
            return changedRows > 0;
        }
    }
}
