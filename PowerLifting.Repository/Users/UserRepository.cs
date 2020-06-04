using Microsoft.EntityFrameworkCore;
using PowerLifting.Persistence;
using PowerLifting.Service.Users.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Powerlifting.Common;
using PowerLifting.Contracts.Contracts;

namespace PowerLifting.Repository.Users
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(PowerliftingContext context) : base(context)
        {

        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await PowerliftingContext.Set<User>().Include(x => x.LiftingStats).Include(x => x.ProgramLogs).AsNoTracking().ToListAsync();
        }

        public async Task<User> GetUserByEmail(string username)
        {
            return await PowerliftingContext.Set<User>().Where(u => u.Email == username).Include(x => x.LiftingStats).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<User> GetUserById(string id)
        {
            return await PowerliftingContext.Set<User>().Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task<User> GetUserByIdIncludeLiftingStats(string id)
        {
            return await PowerliftingContext.Set<User>().Where(u => u.Id == id).Include(x => x.LiftingStats).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task CreateUser(User user)
        {
            await PowerliftingContext.Set<User>().AddAsync(user);
        }

        public void UpdateUser(User user)
        {
            PowerliftingContext.Set<User>().Where(u => u.Id == user.Id).Include(x => x.LiftingStats).AsNoTracking().FirstOrDefaultAsync();
            Save();
        }

        public void DeleteUser(User user)
        {
            PowerliftingContext.Set<User>().Remove(user);
            Save();
        }
    }
}
