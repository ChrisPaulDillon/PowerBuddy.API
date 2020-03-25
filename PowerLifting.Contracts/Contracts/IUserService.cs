using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Entities.DTOs;
using PowerLifting.Entities.Model;

namespace Powerlifting.Contracts.Contracts
{
    public interface IUserService : IServiceBase<User>
    {
        Task<IEnumerable<UserDTO>> GetAllUsers();
        Task<UserDTO> GetUserById(int id);
        Task<UserDTO> GetUserByEmail(string username);
        void DeleteUser(User user);
    }
}
