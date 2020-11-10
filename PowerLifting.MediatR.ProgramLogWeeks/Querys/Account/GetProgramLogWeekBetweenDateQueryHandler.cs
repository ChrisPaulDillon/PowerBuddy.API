using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Exceptions.ProgramLogs;

namespace PowerLifting.MediatR.ProgramLogWeeks.Querys.Account
{
    public class GetProgramLogWeekBetweenDateQuery : IRequest<ProgramLogWeekDTO>
    {
        public DateTime Date { get; }
        public string UserId { get; }

        public GetProgramLogWeekBetweenDateQuery(DateTime date, string userId)
        {
            Date = date;
            UserId = userId;
            new GetProgramLogWeekBetweenDateQueryValidator().ValidateAndThrow(this);
        }
    }

    public class GetProgramLogWeekBetweenDateQueryValidator : AbstractValidator<GetProgramLogWeekBetweenDateQuery>
    {
        public GetProgramLogWeekBetweenDateQueryValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.Date).NotNull().NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
        }
    }

    public class GetProgramLogWeekBetweenDateQueryHandler : IRequestHandler<GetProgramLogWeekBetweenDateQuery, ProgramLogWeekDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public GetProgramLogWeekBetweenDateQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProgramLogWeekDTO> Handle(GetProgramLogWeekBetweenDateQuery request, CancellationToken cancellationToken)
        {
            var programLogWeek = await _context.Set<ProgramLogWeek>()
                .Where(x => x.UserId == request.UserId && request.Date.Date >= x.StartDate.Date &&
                            request.Date.Date <= x.EndDate.Date)
                .ProjectTo<ProgramLogWeekDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (programLogWeek == null) throw new ProgramLogWeekNotFoundException();
            return programLogWeek;
        }
    }
}
