using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.Entities.Account;

namespace PowerLifting.Accounts.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(string id);
        Task<User> GetUserByIdIncludeLiftingStats(string id);
        Task<User> GetUserByEmail(string name);
        Task CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);

        Task<IEnumerable<PublicUserDTO>> GetAllActivePublicProfiles();
    }
}