using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data;
using PowerLifting.Data.DTOs.Exercises;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Exceptions.Exercises;
using PowerLifting.MediatR.Exercises.Command.Account;
using PowerLifting.MediatR.Exercises.Command.Admin;
using Exercise = PowerLifting.Data.Entities.Exercise;

namespace PowerLifting.MediatR.Exercises.CommandHandler.Account
{
    public class CreateExerciseCommandHandler : IRequestHandler<CreateExerciseCommand, ExerciseDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public CreateExerciseCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ExerciseDTO> Handle(CreateExerciseCommand request, CancellationToken cancellationToken)
        {
            var doesExist = await _context.Exercise
                .AsNoTracking()
                .AnyAsync(x => x.ExerciseName == request.Exercise.ExerciseName);

            if (doesExist) throw new ExerciseAlreadyExistsException();

            var exercise = _mapper.Map<Exercise>(request.Exercise);
            _context.Add(exercise);
            await _context.SaveChangesAsync();

            var exerciseDTO = _mapper.Map<ExerciseDTO>(exercise);
            return exerciseDTO;
        }
    }
}
