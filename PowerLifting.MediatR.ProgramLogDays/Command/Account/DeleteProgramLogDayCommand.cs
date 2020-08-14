using MediatR;

namespace PowerLifting.MediatR.ProgramLogDays.Command.Account
{
    public class DeleteProgramLogDayCommand : IRequest<bool>
    {
        public int ProgramLogDayId { get; }
        public string UserId { get; }

        public DeleteProgramLogDayCommand(int programLogDayId, string userId)
        {
            ProgramLogDayId = programLogDayId;
            UserId = userId;
        }
    }
}
