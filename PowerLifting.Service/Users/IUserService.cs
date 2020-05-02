using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Service.Users.DTO;

namespace PowerLifting.Service.Users
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllUsers();
        Task<UserDTO> GetUserById(string id);
        Task<UserDTO> GetUserByEmail(string programType);
        Task RegisterUser(RegisterUserDTO userDTO);
        Task UpdateUser(UserDTO userDTO);
        Task DeleteUser(string id);
    }
}