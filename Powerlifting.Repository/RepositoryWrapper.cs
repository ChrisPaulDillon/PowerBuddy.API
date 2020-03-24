using Powerlifting.Contracts;
using Powerlifting.Contracts.Contracts;
using PowerLifting.Entity.Entities.Data;
using Powerlifting.Repository.Repositories;

namespace Powerlifting.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private PowerliftingContext _repoContext;
        private IUserRepository _user;
        private ILiftingStatsRepository _liftingStats;

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_repoContext);
                }

                return _user;
            }
        }

        public ILiftingStatsRepository LiftingStats
        {
            get
            {
                if (_liftingStats == null)
                {
                    _liftingStats = new LiftingStatsRepository(_repoContext);
                }

                return _liftingStats;
            }
        }

        public RepositoryWrapper(PowerliftingContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChangesAsync();
        }
    }
}