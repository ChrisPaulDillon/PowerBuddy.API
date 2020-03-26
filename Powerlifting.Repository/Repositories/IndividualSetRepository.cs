using System;
using Powerlifting.Repository;
using Powerlifting.Services.IndividualSets.Model;
using PowerLifting.Persistence;
using PowerLifting.Services.IndividualSets;

namespace PowerLifting.Repository.Repositories
{
    public class IndividualSetRepository : RepositoryBase<IndividualSet>, IIndividualSetRepository
    {
        public IndividualSetRepository(PowerliftingContext context) : base(context)
        {
        }
    }
}
