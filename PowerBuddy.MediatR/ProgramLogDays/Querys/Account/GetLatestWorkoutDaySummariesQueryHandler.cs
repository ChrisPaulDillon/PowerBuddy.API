using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Context;
using PowerBuddy.Data.DTOs.ProgramLogs;
using PowerBuddy.Data.Exceptions.ProgramLogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PowerBuddy.MediatR.ProgramLogDays.Querys.Account
{
    public class GetLatestWorkoutDaySummariesQuery : IRequest<IEnumerable<WorkoutDayDTO>>
    {
        public string UserId { get; }

        public GetLatestWorkoutDaySummariesQuery(string userId)
        {
            UserId = userId;
            new GetLatestWorkoutDaySummariesQueryValidator().ValidateAndThrow(this);
        }
    }

    public class GetLatestWorkoutDaySummariesQueryValidator : AbstractValidator<GetLatestWorkoutDaySummariesQuery>
    {
        public GetLatestWorkoutDaySummariesQueryValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' must not be empty");
        }
    }

    public class GetLatestWorkoutDaySummariesQueryHandler : IRequestHandler<GetLatestWorkoutDaySummariesQuery, IEnumerable<WorkoutDayDTO>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public GetLatestWorkoutDaySummariesQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<WorkoutDayDTO>> Handle(GetLatestWorkoutDaySummariesQuery request, CancellationToken cancellationToken)
        {
            var programLogDayDTO = await _context.ProgramLogDay
                .AsNoTracking()
                .Where(x => x.UserId == request.UserId && x.ProgramLogExercises.Any())
                .ProjectTo<WorkoutDayDTO>(_mapper.ConfigurationProvider)
                .Take(50)
                .OrderByDescending(x => x.Date)
                .ToListAsync(cancellationToken: cancellationToken);

            if (programLogDayDTO == null) throw new ProgramLogDayNotFoundException();
            return programLogDayDTO;
        }
    }
}
