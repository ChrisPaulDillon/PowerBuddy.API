using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Powerlifting.Common;
using PowerLifting.Persistence;
using PowerLifting.Service.SystemServices.TemplateDifficultys.DTO;
using PowerLifting.Service.SystemServices.TemplateDifficultys.Model;
using PowerLifting.Systems.Contracts.Repositories;

namespace PowerLifting.Systems.Repository
{
    public class TemplateDifficultyRepository : RepositoryBase<TemplateDifficulty>, ITemplateDifficultyRepository
    {
        private readonly IMapper _mapper;
        public TemplateDifficultyRepository(PowerliftingContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<TemplateDifficultyDTO>> GetAllTemplateDifficulties()
        {
            return await PowerliftingContext.Set<TemplateDifficulty>()
                .ProjectTo<TemplateDifficultyDTO>(_mapper.ConfigurationProvider)
                                .AsNoTracking()
                .ToListAsync();
        }
    }
}
