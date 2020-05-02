using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Service.Users.DTO;
using PowerLifting.Service.Users.Model;

namespace PowerLifting.Service.Users
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllUsers();
        Task<UserDTO> GetUserById(string id);
        Task<UserDTO> GetUserByEmail(string programType);

        /// <summary>
        /// Attempts to login a user using their given email and password
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<UserDTO> LoginUser(LoginModel user);

        Task RegisterUser(RegisterUserDTO userDTO);
        Task UpdateUser(UserDTO userDTO);
        Task DeleteUser(string id);
    }
}