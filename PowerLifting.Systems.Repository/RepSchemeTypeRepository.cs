using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Powerlifting.Common;
using PowerLifting.Persistence;
using PowerLifting.Service.SystemServices.RepSchemeTypes.DTO;
using PowerLifting.Service.SystemServices.RepSchemeTypes.Model;
using PowerLifting.Systems.Contracts;
using PowerLifting.Systems.Contracts.Repositories;

namespace PowerLifting.Systems.Repository
{
    public class RepSchemeTypeRepository : RepositoryBase<RepSchemeType>, IRepSchemeTypeRepository
    {
        private readonly IMapper _mapper;
        public RepSchemeTypeRepository(PowerliftingContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<RepSchemeTypeDTO>> GetAllRepSchemeTypes()
        {
            return await PowerliftingContext.Set<RepSchemeType>()
                .ProjectTo<RepSchemeTypeDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
