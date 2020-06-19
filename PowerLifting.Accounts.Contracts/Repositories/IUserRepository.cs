﻿using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Service.Users.Model;

namespace PowerLifting.Accounts.Contracts.Repositories
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
    }
}