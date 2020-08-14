using MediatR;
using PowerLifting.Data.DTOs.ProgramLogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerLifting.MediatR.ProgramLogExercises.Query.Account
{
    public class GetProgramLogExerciseByIdQuery : IRequest<ProgramLogExerciseDTO>
    {
        public int ProgramLogExerciseId { get; }

        public GetProgramLogExerciseByIdQuery(int programLogExerciseId)
        {
            ProgramLogExerciseId = programLogExerciseId;
        }
    }
}
