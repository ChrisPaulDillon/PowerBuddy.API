using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Exceptions.Workouts;
using PowerBuddy.Data.Factories;
using PowerBuddy.MediatR.WorkoutDays.Models;

namespace PowerBuddy.MediatR.WorkoutDays.Commands
{
    public class CreateWorkoutDayCommand : IRequest<int>
    {
        public CreateWorkoutDayOptions CreateWorkoutDayOptions { get; }
        public string UserId { get; }

        public CreateWorkoutDayCommand(CreateWorkoutDayOptions createWorkoutDayOptions, string userId)
        {
            CreateWorkoutDayOptions = createWorkoutDayOptions;
            UserId = userId;
        }
    }

    public class CreateWorkoutDayCommandValidator : AbstractValidator<CreateWorkoutDayCommand>
    {
        public CreateWorkoutDayCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' must not be empty");
            RuleFor(x => x.CreateWorkoutDayOptions.WorkoutDate).NotNull().NotEmpty().WithMessage("'{PropertyName}' must not be empty");
        }
    }

    internal class CreateWorkoutDayCommandHandler : IRequestHandler<CreateWorkoutDayCommand, int>
    {
        private readonly PowerLiftingContext _context;
        private readonly IEntityFactory _entityFactory;

        public CreateWorkoutDayCommandHandler(PowerLiftingContext context, IEntityFactory entityFactory)
        {
            _context = context;
            _entityFactory = entityFactory;
        }

        public async Task<int> Handle(CreateWorkoutDayCommand request, CancellationToken cancellationToken)
        {
            var workoutAlreadyExists = await _context.WorkoutDay
                .AsNoTracking()
                .AnyAsync(x => x.Date.Date == request.CreateWorkoutDayOptions.WorkoutDate.Date && x.UserId == request.UserId);

            if (workoutAlreadyExists)
            {
                throw new WorkoutDayAlreadyExistsException();
            }

            var workoutDay = new WorkoutDay();

            if (request.CreateWorkoutDayOptions.WorkoutLogId != null && request.CreateWorkoutDayOptions.WeekNo != null) //Create workout as part of a program
            {
                workoutDay = _entityFactory.CreateWorkoutDayWithProgram(
                    (int)request.CreateWorkoutDayOptions.WeekNo, 
                    request.CreateWorkoutDayOptions.WorkoutDate, 
                    (int)request.CreateWorkoutDayOptions.WorkoutLogId,
                    request.UserId);
            }
            else
            {
                workoutDay = _entityFactory.CreateWorkoutDay(0, request.CreateWorkoutDayOptions.WorkoutDate, request.UserId);
            }

            _context.WorkoutDay.Add(workoutDay);
            await _context.SaveChangesAsync(cancellationToken);

            return workoutDay.WorkoutDayId;
        }
    }
}