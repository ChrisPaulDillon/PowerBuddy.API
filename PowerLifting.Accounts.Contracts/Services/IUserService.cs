using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Service.Users.DTO;
using PowerLifting.Service.Users.Model;

namespace PowerLifting.Accounts.Contracts.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllUsers();
        Task<UserDTO> GetUserById(string id);
        Task<UserDTO> GetUserByEmail(string programType);

        Task<UserDTO> GetUserProfile(string userId);
        /// <summary>
        /// Attempts to login a user using their given email and password
        /// </summary>
        /// <returns></returns>
        Task<string> LoginUser(LoginModel user);

        Task RegisterUser(RegisterUserDTO userDTO);
        Task UpdateUser(UserDTO userDTO);
        Task DeleteUser(string id);
    }
}