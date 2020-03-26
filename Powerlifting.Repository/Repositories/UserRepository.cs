using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Powerlifting.Repository;
using Powerlifting.Services.Users.Model;
using PowerLifting.Persistence;
using PowerLifting.Services.Users;

namespace PowerLifting.Repository.Repositories
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

        public async Task<User> GetUserById(int id)
        {
            return await PowerliftingContext.Set<User>().Where(u => u.UserId == id).Include(x => x.LiftingStats).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task CreateUser(User user)
        {
            await PowerliftingContext.Set<User>().AddAsync(user);
        }

        public void UpdateUser(User user)
        {
            PowerliftingContext.Set<User>().Where(u => u.UserId == user.UserId).Include(x => x.LiftingStats).AsNoTracking().FirstOrDefaultAsync();
            Save();
        }

        public void DeleteUser(User user)
        {
            PowerliftingContext.Set<User>().Remove(user);
            Save();
        }
    }
}
