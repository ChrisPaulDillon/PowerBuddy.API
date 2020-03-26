using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Powerlifting.Services.Users.DTO;

namespace PowerLifting.Services.Users
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllUsers();
        Task<UserDTO> GetUserById(int programTemplateId);
        Task<UserDTO> GetUserByEmail(string programType);
        Task<UserDTO> CreateUser(UserDTO user);
        Task UpdateUser(UserDTO userDTO);
        Task DeleteUser(int id);
    }
}

