using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Powerlifting.Contracts.Contracts;
using PowerLifting.Entity.Entities;
using PowerLifting.Entity.Entities.Data;

namespace Powerlifting.Repository.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(PowerliftingContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<User> GetByUserId(int id)
        {
            return await PowerliftingContext.Set<User>().Where(user => user.UserId == id).Include(x => x.LiftingStats).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<User> GetByUsername(string username)
        {
            return await PowerliftingContext.Set<User>().Where(user => user.Username == username).Include(x => x.LiftingStats).AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
