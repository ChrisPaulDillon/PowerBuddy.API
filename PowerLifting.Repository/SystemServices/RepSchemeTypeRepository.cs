using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Powerlifting.Repository;
using PowerLifting.Persistence;
using PowerLifting.Service.SystemServices.RepSchemeTypes;
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
