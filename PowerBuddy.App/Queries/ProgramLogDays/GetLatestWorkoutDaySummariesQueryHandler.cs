using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Dtos.Workouts;

namespace PowerBuddy.App.Queries.ProgramLogDays
{
    public class GetLatestWorkoutDaySummariesQuery : IRequest<IEnumerable<WorkoutDaySummaryDto>>
    {
        public string UserId { get; }

        public GetLatestWorkoutDaySummariesQuery(string userId)
        {
            UserId = userId;
        }
    }

    public class GetLatestWorkoutDaySummariesQueryValidator : AbstractValidator<GetLatestWorkoutDaySummariesQuery>
    {
        public GetLatestWorkoutDaySummariesQueryValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' must not be empty");
        }
    }

    public class GetLatestWorkoutDaySummariesQueryHandler : IRequestHandler<GetLatestWorkoutDaySummariesQuery, IEnumerable<WorkoutDaySummaryDto>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public GetLatestWorkoutDaySummariesQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<WorkoutDaySummaryDto>> Handle(GetLatestWorkoutDaySummariesQuery request, CancellationToken cancellationToken)
        {
            var programLogDayDto = await _context.ProgramLogDay
                .AsNoTracking()
                .Where(x => x.UserId == request.UserId && x.ProgramLogExercises.Any())
                .ProjectTo<WorkoutDaySummaryDto>(_mapper.ConfigurationProvider)
                .Take(50)
                .OrderByDescending(x => x.Date)
                .ToListAsync(cancellationToken: cancellationToken);

            return programLogDayDto;
        }
    }
}
