using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper;
using Powerlifting.Services.Users.DTO;
using PowerLifting.Services.Service.Users.Exceptions;
using Powerlifting.Services.Users.Model;
using Powerlifting.Services.ServiceWrappers;
using PowerLifting.Services.Users;

namespace Powerlifting.Services.Users
{
    public class UserService : ServiceBase<User>, IUserService
    {
        private IMapper _mapper;

        public UserService(IUserRepository ServiceContext, IMapper mapper)
            : base(ServiceContext)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsers()
        {
            var users = await PowerliftingContext.Set<User>().Include(x => x.LiftingStats).Include(x => x.ProgramLogs).AsNoTracking().ToListAsync();
            var usersDTO = _mapper.Map<List<UserDTO>>(users);
            return usersDTO;
        }

        public async Task<UserDTO> GetUserById(int id)
        {
            var user = await PowerliftingContext.Set<User>().Where(u => u.UserId == id).Include(x => x.LiftingStats).AsNoTracking().FirstOrDefaultAsync();
            if (user == null)
            {
                throw new UserNotFoundException();
            }
            var userDTO = _mapper.Map<UserDTO>(user);
            return userDTO;
        }

        public async Task<UserDTO> GetUserByEmail(string username)
        {
            var user = await PowerliftingContext.Set<User>().Where(u => u.Email == username).Include(x => x.LiftingStats).AsNoTracking().FirstOrDefaultAsync();
            var userDTO = _mapper.Map<UserDTO>(user);
            return userDTO;
        }

        public async Task CreateUser(UserDTO userDTO)
        {
            var user = await PowerliftingContext.Set<User>().Where(u => u.UserId == userDTO.UserId).Include(x => x.LiftingStats).AsNoTracking().FirstOrDefaultAsync();
            if (user != null)
            {
                throw new EmailInUseException();
            }
            var ownerEntity = _mapper.Map<User>(userDTO);
            await PowerliftingContext.Set<User>().AddAsync(ownerEntity);
        }

        public async Task UpdateUser(UserDTO userDTO)
        {
            var user = await PowerliftingContext.Set<User>().Where(u => u.UserId == userDTO.UserId).Include(x => x.LiftingStats).AsNoTracking().FirstOrDefaultAsync();
            if(user == null)
            {
                throw new UserNotFoundException();
            }
            _mapper.Map(userDTO, user);
            PowerliftingContext.Set<User>().Update(user);
        }

        public async Task DeleteUser(int userId)
        {
            var user = await PowerliftingContext.Set<User>().Where(u => u.UserId == userId).Include(x => x.LiftingStats).AsNoTracking().FirstOrDefaultAsync();
            if (user == null)
            {
                throw new UserNotFoundException();
            }
            PowerliftingContext.Set<User>().Remove(user);
        }
    }
}
