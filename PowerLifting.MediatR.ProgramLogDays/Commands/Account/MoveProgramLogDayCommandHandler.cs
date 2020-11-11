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
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.Data.Exceptions.ProgramLogs;
using PowerLifting.Data.Factories;

namespace PowerLifting.MediatR.ProgramLogDays.Commands.Account
{
    public class MoveProgramLogDayCommand : IRequest<ProgramLogDayDTO>
    {
        public ProgramLogDayDTO ProgramLogDayDTO { get; }
        public DateTime MoveDate { get; }
        public string UserId { get; }

        public MoveProgramLogDayCommand(ProgramLogDayDTO programLogDayDTO, DateTime moveDate, string userId)
        {
            ProgramLogDayDTO = programLogDayDTO;
            MoveDate = moveDate;
            UserId = userId;
            new MoveProgramLogDayCommandValidator().ValidateAndThrow(this);
        }
    }

    public class MoveProgramLogDayCommandValidator : AbstractValidator<MoveProgramLogDayCommand>
    {
        public MoveProgramLogDayCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' must not be empty");
            RuleFor(x => x.ProgramLogDayDTO.Date).NotNull().NotEmpty().WithMessage("'{PropertyName}' must not be empty");
        }
    }

    public class MoveProgramLogDayCommandHandler : IRequestHandler<MoveProgramLogDayCommand, ProgramLogDayDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly IDTOFactory _dtoFactory;

        public MoveProgramLogDayCommandHandler(PowerLiftingContext context, IMapper mapper, IDTOFactory dtoFactory)
        {
            _context = context;
            _mapper = mapper;
            _dtoFactory = dtoFactory;
        }

        public async Task<ProgramLogDayDTO> Handle(MoveProgramLogDayCommand request, CancellationToken cancellationToken)
        {
            if (request.UserId != request.ProgramLogDayDTO.UserId) throw new UnauthorisedUserException();

            var programLogWeek = await _context.ProgramLogWeek.Where(x => x.ProgramLogWeekId == request.ProgramLogDayDTO.ProgramLogWeekId)
                .AsNoTracking()
                .ProjectTo<ProgramLogWeekDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (programLogWeek == null) throw new ProgramLogWeekNotFoundException();

            var programLogOnMoveDate = programLogWeek.ProgramLogDays.FirstOrDefault(x => x.Date.Date.CompareTo(request.ProgramLogDayDTO.Date) == 0);

            if (programLogOnMoveDate != null && programLogOnMoveDate.ProgramLogExercises.Any())
            {
                throw new ProgramLogDayOnDateAlreadyActiveException();
            }

            if (programLogOnMoveDate != null) //swap the original day with the new one
            {
                var oldProgramLogDay = _mapper.Map<ProgramLogDay>(programLogOnMoveDate);
                oldProgramLogDay.Date = request.ProgramLogDayDTO.Date;
                _context.ProgramLogDay.Update(oldProgramLogDay);
            }
            else
            {
                // create a new day to replace the day being changed to a new date
                var programLogDay = _dtoFactory.CreateProgramLogDayDTO(request.ProgramLogDayDTO.Date, request.UserId);
                _context.ProgramLogDay.Add(_mapper.Map<ProgramLogDay>(programLogDay));
            }

            request.ProgramLogDayDTO.Date = request.MoveDate;
            _context.ProgramLogDay.Add(_mapper.Map<ProgramLogDay>(request.ProgramLogDayDTO));

            await _context.SaveChangesAsync();

            return request.ProgramLogDayDTO;
        }
    }
}
