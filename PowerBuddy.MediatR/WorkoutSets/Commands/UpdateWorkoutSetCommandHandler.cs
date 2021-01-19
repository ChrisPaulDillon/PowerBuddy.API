﻿using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.DTOs.Workouts;
using PowerBuddy.Data.Entities;
using PowerBuddy.Services.Workouts;

namespace PowerBuddy.MediatR.WorkoutSets.Commands
{
    public class UpdateWorkoutSetCommand : IRequest<bool>
    {
        public int WorkoutDayId { get; }
        public WorkoutSetDTO WorkoutSetDTO { get; }
        public string UserId { get; }

        public UpdateWorkoutSetCommand(int workoutDayId, WorkoutSetDTO workoutSetDTO, string userId)
        {
            WorkoutDayId = workoutDayId;
            WorkoutSetDTO = workoutSetDTO;
            UserId = userId;
        }
    }

    internal class UpdateWorkoutSetCommandHandler : IRequestHandler<UpdateWorkoutSetCommand, bool>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly IWorkoutService _workoutService;

        public UpdateWorkoutSetCommandHandler(PowerLiftingContext context, IMapper mapper, IWorkoutService workoutService)
        {
            _context = context;
            _mapper = mapper;
            _workoutService = workoutService;
        }

        public async Task<bool> Handle(UpdateWorkoutSetCommand request, CancellationToken cancellationToken)
        {
            var doesSetExist = await _context.WorkoutSet
                .AsNoTracking()
                .AnyAsync(x => x.WorkoutSetId == request.WorkoutSetDTO.WorkoutSetId);

            if (!doesSetExist) return false;

            var workoutDay = await _context.ProgramLogDay.FirstOrDefaultAsync(x => x.ProgramLogDayId == request.WorkoutDayId && x.UserId == request.UserId);
            if (workoutDay == null)
            {
                return false;
            }

            workoutDay.Completed = false;

            var workoutSet = _mapper.Map<WorkoutSet>(request.WorkoutSetDTO);
            _context.WorkoutSet.Update(workoutSet);

            await _context.SaveChangesAsync(cancellationToken);

            var workoutExerciseTonnageUpdate = await _context.WorkoutExercise
                .AsNoTracking()
                .Include(x => x.WorkoutSets)
                .Include(x => x.WorkoutExerciseTonnage)
                .FirstOrDefaultAsync(x => x.WorkoutExerciseId == request.WorkoutSetDTO.WorkoutExerciseId);

            workoutExerciseTonnageUpdate.WorkoutExerciseTonnage = await _workoutService.UpdateExerciseTonnage(workoutExerciseTonnageUpdate, request.UserId);

            var modifiedRows = await _context.SaveChangesAsync(cancellationToken);

            return modifiedRows > 0;
        }
    }
}