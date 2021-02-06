using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OneOf;
using PowerBuddy.App.Commands.WorkoutDays.Models;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Factories;
using PowerBuddy.Data.Models.Workouts;

namespace PowerBuddy.App.Commands.WorkoutDays
{
    public class CreateWorkoutDayCommand : IRequest<OneOf<int, WorkoutDayAlreadyExists>>
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

    public class CreateWorkoutDayCommandHandler : IRequestHandler<CreateWorkoutDayCommand, OneOf<int, WorkoutDayAlreadyExists>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IEntityFactory _entityFactory;

        public CreateWorkoutDayCommandHandler(PowerLiftingContext context, IEntityFactory entityFactory)
        {
            _context = context;
            _entityFactory = entityFactory;
        }

        public async Task<OneOf<int, WorkoutDayAlreadyExists>> Handle(CreateWorkoutDayCommand request, CancellationToken cancellationToken)
        {
            var workoutAlreadyExists = await _context.WorkoutDay
                .AsNoTracking()
                .AnyAsync(x => x.Date.Date == request.CreateWorkoutDayOptions.WorkoutDate.Date && x.UserId == request.UserId, cancellationToken: cancellationToken);

            if (workoutAlreadyExists)
            {
                return new WorkoutDayAlreadyExists();
            }

            WorkoutDay workoutDay;

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

            await _context.WorkoutDay.AddAsync(workoutDay, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return workoutDay.WorkoutDayId;
        }
    }
}