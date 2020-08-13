using MediatR;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.Entities.ProgramLogs;

namespace PowerLifting.MediatR.ProgramLogs.Command.Account
{
    public class CreateProgramLogFromScratchCommand : IRequest<ProgramLog>
    {
        public CProgramLogDTO ProgramLogDTO { get; }
        public string UserId { get; }

        public CreateProgramLogFromScratchCommand(CProgramLogDTO programLogDTO, string userId)
        {
            ProgramLogDTO = programLogDTO;
            UserId = userId;
        }
    }
}