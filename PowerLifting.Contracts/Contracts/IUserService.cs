using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Entities.Model;

namespace Powerlifting.Contracts.Contracts
{
    public interface IUserService : IServiceBase<User>
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<User> GetUserByEmail(string username);

        void DeleteUser(User user);
    }
}
