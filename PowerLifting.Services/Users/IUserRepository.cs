using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Powerlifting.Services.Users.DTO;

namespace PowerLifting.Services.Users
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDTO>> GetAllUsers();
    }
}
