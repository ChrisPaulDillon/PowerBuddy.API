using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.Data.Exceptions.Exercises;
using PowerLifting.MediatR.Exercises.Command.Admin;
using Exercise = PowerLifting.Data.Entities.Exercise;

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
            var doesExerciseExist = await _context.Exercise.AsNoTracking().AnyAsync(x => x.ExerciseId == request.Exercise.ExerciseId);

            if (!doesExerciseExist) throw new ExerciseNotFoundException();

            var exercise = _mapper.Map<Exercise>(request.Exercise);
            _context.Exercise.Update(exercise);

            var changedRows = await _context.SaveChangesAsync(cancellationToken);
            return changedRows > 0;
        }
    }
}
