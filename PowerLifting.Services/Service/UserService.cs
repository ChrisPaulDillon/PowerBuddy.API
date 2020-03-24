using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Powerlifting.Contracts.Contracts;
using PowerLifting.Entities.Model;
using PowerLifting.Persistence;
using Powerlifting.Services;
using System.Collections.Generic;

namespace Powerlifting.Services.Service
{
    public class UserService : ServiceBase<User>, IUserService
    {
        public UserService(PowerliftingContext ServiceContext)
            : base(ServiceContext)
        {
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await PowerliftingContext.Set<User>().Include(x => x.LiftingStats).Include(x => x.ProgramLogs).AsNoTracking().ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await PowerliftingContext.Set<User>().Where(user => user.UserId == id).Include(x => x.LiftingStats).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<User> GetUserByEmail(string username)
        {
            return await PowerliftingContext.Set<User>().Where(user => user.Email == username).Include(x => x.LiftingStats).AsNoTracking().FirstOrDefaultAsync();
        }

        public void DeleteUser(User user)
        {
            Delete(user);
        }
    }
}
