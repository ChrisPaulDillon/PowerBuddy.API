using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Entity.Users.DTO;
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
        /// Gets the users public profile if they have a public profile enabled
        /// </summary>
        Task<PublicUserDTO> GetPublicUserProfileById(string id);

        /// <summary>
        /// Gets the users public profile if they have a public profile enabled
        /// </summary>
        Task<PublicUserDTO> GetPublicUserProfileByUserName(string userName);

        Task<IEnumerable<PublicUserDTO>> GetAllActivePublicProfiles();

        /// <summary>
        /// Attempts to login a user using their given email and password
        /// </summary>
        Task<string> LoginUser(LoginModel user);

        Task RegisterUser(RegisterUserDTO userDTO);
        Task UpdateUser(UserDTO userDTO);
        Task DeleteUser(string id);
    }
}