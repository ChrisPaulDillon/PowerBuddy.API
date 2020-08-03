using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.Entities.Account;

namespace PowerLifting.Accounts.Service
{
    public interface IUserService
    {
        Task<IEnumerable<AdminUserDTO>> GetAllAdminUsers();

        Task<UserDTO> GetUserProfile(string userId);

        Task<PublicUserDTO> GetPublicUserProfileById(string id);

        Task<PublicUserDTO> GetPublicUserProfileByUserName(string userName);

        Task<IEnumerable<PublicUserDTO>> GetAllActivePublicProfiles();

        Task<string> LoginUser(LoginModel user);

        Task RegisterUser(RegisterUserDTO userDTO);

        Task<bool> BanUser(string userId, string adminUserId);
    }
}