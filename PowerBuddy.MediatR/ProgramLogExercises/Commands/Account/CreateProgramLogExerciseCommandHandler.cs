﻿using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Context;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.DTOs.ProgramLogs;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Exceptions.Exercises;
using PowerBuddy.Data.Exceptions.ProgramLogs;
using PowerBuddy.Data.Factories;
using PowerBuddy.MediatR.ProgramLogExercises.Util;
using PowerBuddy.Services.ProgramLogs;

namespace PowerBuddy.MediatR.ProgramLogExercises.Commands.Account
{
    public class CreateProgramLogExerciseCommand : IRequest<ProgramLogExerciseDTO>
    {
        public ProgramLogExerciseDTO ProgramLogExerciseDTO { get; }
        public string UserId { get; }

        public CreateProgramLogExerciseCommand(ProgramLogExerciseDTO programLogExerciseDTO, string userId)
        {
            ProgramLogExerciseDTO = programLogExerciseDTO;
            UserId = userId;
            new CreateProgramLogExerciseCommandValidator().ValidateAndThrow(this);
        }
    }

    public class CreateProgramLogExerciseCommandValidator : AbstractValidator<CreateProgramLogExerciseCommand>
    {
        public CreateProgramLogExerciseCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' must not be empty");
            RuleFor(x => x.ProgramLogExerciseDTO.ExerciseId).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than 0.");
            RuleFor(x => x.ProgramLogExerciseDTO.NoOfSets).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than 0.");
            RuleFor(x => x.ProgramLogExerciseDTO.ProgramLogDayId).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than 0.");
        }
    }

    public class CreateProgramLogExerciseCommandHandler : IRequestHandler<CreateProgramLogExerciseCommand, ProgramLogExerciseDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IProgramLogService _programLogService;
        private readonly IEntityFactory _entityFactory;

        public CreateProgramLogExerciseCommandHandler(PowerLiftingContext context, IMapper mapper, IMediator mediator, IProgramLogService programLogService, IEntityFactory entityFactory)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
            _programLogService = programLogService;
            _entityFactory = entityFactory;
        }

        public async Task<ProgramLogExerciseDTO> Handle(CreateProgramLogExerciseCommand request, CancellationToken cancellationToken)
        {
            var programLogDay = await _context.ProgramLogDay.FirstOrDefaultAsync(x => x.ProgramLogDayId == request.ProgramLogExerciseDTO.ProgramLogDayId, cancellationToken: cancellationToken);
            if (programLogDay == null) throw new ProgramLogDayNotFoundException();

            programLogDay.Completed = false; //day is no longer completed if an exercise is added to it

            var doesExerciseExist = await _context.Exercise.AsNoTracking().AnyAsync(x => x.ExerciseId == request.ProgramLogExerciseDTO.ExerciseId, cancellationToken: cancellationToken);
            if (!doesExerciseExist) throw new ExerciseNotFoundException();

            var programLogExerciseEntity = await _context.ProgramLogExercise
                .AsNoTracking()
                .Include(x => x.ProgramLogRepSchemes)
                .FirstOrDefaultAsync(x => x.ProgramLogDayId == request.ProgramLogExerciseDTO.ProgramLogDayId && x.ExerciseId == request.ProgramLogExerciseDTO.ExerciseId, cancellationToken: cancellationToken);

            var noOfSetsToAdd = request.ProgramLogExerciseDTO.NoOfSets;

            if (programLogExerciseEntity == null) //no exercise found for this day, create a fresh one
            {
                var createdProgramLogExercise = _programLogService.CreateRepSchemesForExercise(request.ProgramLogExerciseDTO, request.UserId);

                programLogExerciseEntity = _mapper.Map<ProgramLogExercise>(createdProgramLogExercise);
                _context.ProgramLogExercise.Add(programLogExerciseEntity);

                await _mediator.Send(new CreateProgramLogExerciseAuditCommand(request.ProgramLogExerciseDTO.ExerciseId, request.UserId), cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                var mappedProgramLogExercise = _mapper.Map<ProgramLogExerciseDTO>(programLogExerciseEntity);
                mappedProgramLogExercise.ExerciseName = await _context.Exercise.AsNoTracking().Where(x => x.ExerciseId == mappedProgramLogExercise.ExerciseId).Select(x => x.ExerciseName).FirstOrDefaultAsync(cancellationToken: cancellationToken);
                return mappedProgramLogExercise;
            }
            else //update existing program log exercise
            {
                var totalNoOfSets = programLogExerciseEntity.NoOfSets + noOfSetsToAdd;
                if (totalNoOfSets >= ProgramLogExerciseConstants.MAX_NO_OF_SETS) throw new ReachedMaxSetsOnExerciseException();
                
                for (var i = 1; i < noOfSetsToAdd + 1; i++)
                {
                    if (request.ProgramLogExerciseDTO.Reps != null && request.ProgramLogExerciseDTO.Weight != null)
                    {
                        var repScheme = _entityFactory.CreateRepScheme(programLogExerciseEntity.ProgramLogExerciseId, i, (int) request.ProgramLogExerciseDTO.Reps, (decimal) request.ProgramLogExerciseDTO.Weight);
                        programLogExerciseEntity.ProgramLogRepSchemes.Add(repScheme);
                    }
                }

                programLogExerciseEntity.NoOfSets += request.ProgramLogExerciseDTO.NoOfSets;
                await _context.SaveChangesAsync(cancellationToken);

                var mappedProgramLogExercise = _mapper.Map<ProgramLogExerciseDTO>(programLogExerciseEntity);
                return mappedProgramLogExercise;
            }
        }
    }
}
