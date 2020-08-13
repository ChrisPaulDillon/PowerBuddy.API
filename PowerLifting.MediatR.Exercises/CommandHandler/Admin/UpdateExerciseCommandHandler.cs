using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data.Entities.Exercises;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.Data.Exceptions.Exercises;
using PowerLifting.MediatR.Exercises.Command.Admin;
using PowerLifting.Persistence;

namespace PowerLifting.MediatR.Exercises.CommandHandler.Admin
{
    public class UpdateExerciseCommandHandler : IRequestHandler<UpdateExerciseCommand, bool>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public UpdateExerciseCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateExerciseCommand request, CancellationToken cancellationToken)
        {
            var exercise = await _context.Exercise
                .FirstOrDefaultAsync(x => x.ExerciseId == request.Exercise.ExerciseId);

            if (exercise == null) throw new ExerciseNotFoundException();

            _mapper.Map(request.Exercise, exercise);
            _context.Update(exercise);

            var changedRows = await _context.SaveChangesAsync();
            return changedRows > 0;
        }
    }
}
