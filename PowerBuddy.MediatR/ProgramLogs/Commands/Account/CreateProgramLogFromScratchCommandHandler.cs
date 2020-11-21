using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using PowerBuddy.Context;
using PowerBuddy.Data.DTOs.ProgramLogs;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Exceptions.Account;
using PowerBuddy.Data.Factories;
using PowerBuddy.Services.ProgramLogs;
using PowerBuddy.Util.Extensions;

namespace PowerBuddy.MediatR.ProgramLogs.Commands.Account
{
    public class CreateProgramLogFromScratchCommand : IRequest<ProgramLog>
    {
        public ProgramLogInputScratchDTO ProgramLogDTO { get; }
        public string UserId { get; }

        public CreateProgramLogFromScratchCommand(ProgramLogInputScratchDTO programLogDTO, string userId)
        {
            ProgramLogDTO = programLogDTO;
            UserId = userId;
            new CreateProgramLogFromScratchCommandValidator().ValidateAndThrow(this);
        }
    }

    public class CreateProgramLogFromScratchCommandValidator : AbstractValidator<CreateProgramLogFromScratchCommand>
    {
        public CreateProgramLogFromScratchCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.ProgramLogDTO.UserId).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.ProgramLogDTO.NoOfWeeks).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than {ComparisonValue}.");
            RuleFor(x => x.ProgramLogDTO.UserId).Matches(x => x.UserId).WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.ProgramLogDTO.CustomName).MaximumLength(180).WithMessage("'{PropertyName}' should be no longer than {MaxLength} characters.");
        }
    }

    public class CreateProgramLogFromScratchCommandHandler : IRequestHandler<CreateProgramLogFromScratchCommand, ProgramLog>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly IProgramLogService _programLogService;
        private readonly IDTOFactory _dtoFactory;
        public CreateProgramLogFromScratchCommandHandler(PowerLiftingContext context, IMapper mapper, IProgramLogService programLogService, IDTOFactory dtoFactory)
        {
            _context = context;
            _mapper = mapper;
            _programLogService = programLogService;
            _dtoFactory = dtoFactory;
        }

        public async Task<ProgramLog> Handle(CreateProgramLogFromScratchCommand request, CancellationToken cancellationToken)
        {
            if (request.ProgramLogDTO.UserId != request.UserId) throw new UnauthorisedUserException();
            await _programLogService.IsProgramLogAlreadyActive(request.ProgramLogDTO.StartDate, request.ProgramLogDTO.EndDate, request.UserId);

            var listOfProgramWeeks = new List<ProgramLogWeekDTO>();

            var startDate = request.ProgramLogDTO.StartDate.StartOfWeek(DayOfWeek.Monday);

            for (var i = 0; i < request.ProgramLogDTO.NoOfWeeks; i++)
            {
                var programLogWeek = _dtoFactory.CreateProgramLogWeekDTO(startDate, i + 1, request.UserId);
                startDate = startDate.AddDays(7);
                listOfProgramWeeks.Add(programLogWeek);
            }

            request.ProgramLogDTO.ProgramLogWeeks = listOfProgramWeeks;
            request.ProgramLogDTO.StartDate = request.ProgramLogDTO.StartDate.StartOfWeek(DayOfWeek.Monday);
            request.ProgramLogDTO.EndDate = startDate.AddDays(request.ProgramLogDTO.NoOfWeeks);

            var programLogEntity = _mapper.Map<ProgramLog>(request.ProgramLogDTO);
            _context.ProgramLog.Add(programLogEntity);
            await _context.SaveChangesAsync(cancellationToken);
            return programLogEntity;
        }
    }
}
