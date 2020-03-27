using System.Collections.Generic;
using System.Threading.Tasks;
using Powerlifting.Services.Users.Model;

namespace PowerLifting.Services.Users
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<User> GetUserByEmail(string name);
        Task CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}
