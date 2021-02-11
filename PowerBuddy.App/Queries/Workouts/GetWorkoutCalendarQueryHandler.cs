using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;

namespace PowerBuddy.App.Queries.Workouts
{
    public class GetWorkoutCalendarQuery : IRequest<IEnumerable<DateTime>>
    {
        public string UserId { get; }

        public GetWorkoutCalendarQuery(string userId)
        {
            UserId = userId;
        }
    }

    public class GetWorkoutCalendarQueryValidator : AbstractValidator<GetWorkoutCalendarQuery>
    {
        public GetWorkoutCalendarQueryValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
        }
    }

    internal class GetWorkoutCalendarQueryHandler : IRequestHandler<GetWorkoutCalendarQuery, IEnumerable<DateTime>>
    {
        private readonly PowerLiftingContext _context;

        public GetWorkoutCalendarQueryHandler(PowerLiftingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DateTime>> Handle(GetWorkoutCalendarQuery request, CancellationToken cancellationToken)
        {
            return await _context.WorkoutDay
                .AsNoTracking()
                .Where(x => x.UserId == request.UserId)
                .Select(x => x.Date)
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
