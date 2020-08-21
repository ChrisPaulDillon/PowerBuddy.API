using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.ProgramLogs;

namespace PowerLifting.MediatR.ProgramLogExercises.Command.Account
{
    public class UpdateProgramLogExerciseNotesCommand : IRequest<bool>
    {
        public int ProgramLogExerciseId { get; }
        public string Notes { get; }
        public string UserId { get; }

        public UpdateProgramLogExerciseNotesCommand(int programLogExerciseId, string notes, string userId)
        {
            ProgramLogExerciseId = programLogExerciseId;
            Notes = notes;
            UserId = userId;
        }
    }
}