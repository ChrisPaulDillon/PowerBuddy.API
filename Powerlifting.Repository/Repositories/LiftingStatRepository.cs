using System;
using Powerlifting.Repository;
using Powerlifting.Service.LiftingStats.Model;
using PowerLifting.Persistence;
using PowerLifting.Services.LiftingStats;

namespace PowerLifting.Repository.Repositories
{
    public class LiftingStatRepository : RepositoryBase<LiftingStat>, ILiftingStatRepository
    {
        public LiftingStatRepository(PowerliftingContext context) : base(context)
        {
        }
    }
}
