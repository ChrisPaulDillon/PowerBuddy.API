using System;
using Powerlifting.Repository;
using Powerlifting.Services.ProgramLogs;
using PowerLifting.Persistence;
using PowerLifting.Services.ProgramLogs;

namespace PowerLifting.Repository.Repositories
{
    public class ProgramLogRepository : RepositoryBase<ProgramLog>, IProgramLogRepository
    {
        public ProgramLogRepository(PowerliftingContext context) : base(context)
        {
        }
    }
}
