using Microsoft.EntityFrameworkCore;
using PowerLifting.Persistence;
using PowerLifting.Service.Users.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PowerLifting.Accounts.Contracts.Repositories;
using AutoMapper;

namespace PowerLifting.Accounts.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly PowerliftingContext _context;
        private readonly IMapper _mapper;

        public UserRepository(PowerliftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.Set<User>().Include(x => x.LiftingStats).Include(x => x.ProgramLogs).AsNoTracking().ToListAsync();
        }

        public async Task<User> GetUserByEmail(string username)
        {
            return await _context.Set<User>().Where(u => u.Email == username).Include(x => x.LiftingStats).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<User> GetUserById(string id)
        {
            return await _context.Set<User>().Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task<User> GetUserByIdIncludeLiftingStats(string id)
        {
            return await _context.Set<User>().Where(u => u.Id == id).Include(x => x.LiftingStats).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task CreateUser(User user)
        {
            _context.Set<User>().Add(user);
        }

        public void UpdateUser(User user)
        {
            _context.Set<User>().Where(u => u.Id == user.Id).Include(x => x.LiftingStats).AsNoTracking().FirstOrDefaultAsync();
        }

        public void DeleteUser(User user)
        {
            _context.Set<User>().Remove(user);
        }
    }
}
