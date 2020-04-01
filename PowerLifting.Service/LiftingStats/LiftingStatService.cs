using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Powerlifting.Service.LiftingStats.Model;
using PowerLifting.Service.ServiceWrappers;
using PowerLifting.Service.Users.Model;
using PowerLifting.Services.LiftingStats;

namespace Powerlifting.Service.LiftingStats
{
    public class LiftingStatService : ILiftingStatService
    {
        private IMapper _mapper;
        private IRepositoryWrapper _repo;

        public LiftingStatService(IRepositoryWrapper repo, IMapper mapper, UserManager<User>)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public void UpdateLiftingStats(LiftingStat stats)
        {
            //Update(stats);
        }
    }
}
