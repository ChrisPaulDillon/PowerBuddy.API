using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Powerlifting.Common;
using PowerLifting.Contracts.Contracts;
using PowerLifting.Persistence;
using PowerLifting.Service.SystemServices.RepSchemeTypes.Model;

namespace PowerLifting.Repository.SystemServices
{
    public class RepSchemeTypeRepository : RepositoryBase<RepSchemeType>, IRepSchemeTypeRepository
    {
        public RepSchemeTypeRepository(PowerliftingContext context) : base(context)
        {
        }

        public async Task<IEnumerable<RepSchemeType>> GetAllExerciseTypes()
        {
            return await PowerliftingContext.Set<RepSchemeType>().AsNoTracking().ToListAsync();
        }
    }
}
