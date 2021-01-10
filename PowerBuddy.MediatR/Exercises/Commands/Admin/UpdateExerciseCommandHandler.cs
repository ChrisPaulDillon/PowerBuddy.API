using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.DTOs.Exercises;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Exceptions.Exercises;

namespace PowerBuddy.MediatR.Exercises.Commands.Admin
{
    public class UpdateExerciseCommand : IRequest<bool>
    {
        public ExerciseDTO Exercise { get; }
        public string UserId { get; }

        public UpdateExerciseCommand(ExerciseDTO exercise, string userId)
        {
            Exercise = exercise;
            UserId = userId;
        }
    }
    internal class UpdateExerciseCommandHandler : IRequestHandler<UpdateExerciseCommand, bool>
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
            var doesExerciseExist = await _context.Exercise.AsNoTracking().AnyAsync(x => x.ExerciseId == request.Exercise.ExerciseId, cancellationToken: cancellationToken);

            if (!doesExerciseExist) throw new ExerciseNotFoundException();

            var exercise = _mapper.Map<Exercise>(request.Exercise);
            _context.Exercise.Update(exercise);

            var changedRows = await _context.SaveChangesAsync(cancellationToken);
            return changedRows > 0;
        }
    }
}
