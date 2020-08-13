using MediatR;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.DTOs.Templates;
using PowerLifting.Data.Entities.ProgramLogs;

namespace PowerLifting.MediatR.ProgramLogs.Command.Account
{
    public class DeleteProgramLogCommand : IRequest<bool>
    {
        public int ProgramLogId { get; }
        public string UserId { get; }

        public DeleteProgramLogCommand(int programLogId, string userId)
        {
            ProgramLogId = programLogId;
            UserId = userId;
        }
    }
}