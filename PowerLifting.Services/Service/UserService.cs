using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Powerlifting.Contracts.Contracts;
using PowerLifting.Entities.Model;
using PowerLifting.Persistence;
using Powerlifting.Services;
using System.Collections.Generic;
using AutoMapper;
using PowerLifting.Entities.DTOs;

namespace Powerlifting.Services.Service
{
    public class UserService : ServiceBase<User>, IUserService
    {
        private IMapper _mapper;

        public UserService(PowerliftingContext ServiceContext, IMapper mapper)
            : base(ServiceContext)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsers()
        {
            var users = await PowerliftingContext.Set<User>().Include(x => x.LiftingStats).Include(x => x.ProgramLogs).AsNoTracking().ToListAsync();
            var usersDTO = _mapper.Map<IEnumerable<UserDTO>>(users);
            return usersDTO;
        }

        public async Task<UserDTO> GetUserById(int id)
        {
            var user = await PowerliftingContext.Set<User>().Where(u => u.UserId == id).Include(x => x.LiftingStats).AsNoTracking().FirstOrDefaultAsync();
            var userDTO = _mapper.Map<UserDTO>(user);
            return userDTO;
        }

        public async Task<UserDTO> GetUserByEmail(string username)
        {
            var user = await PowerliftingContext.Set<User>().Where(u => u.Email == username).Include(x => x.LiftingStats).AsNoTracking().FirstOrDefaultAsync();
            var userDTO = _mapper.Map<UserDTO>(user);
            return userDTO;
        }

        public void DeleteUser(User user)
        {
            Delete(user);
        }
    }
}
