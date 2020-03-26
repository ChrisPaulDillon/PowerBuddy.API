using System;
using Powerlifting.Repository;
using Powerlifting.Services.Users.Model;
using PowerLifting.Persistence;
using PowerLifting.Services.Users;

namespace PowerLifting.Repository.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(PowerliftingContext context) : base(context)
        {
        }
    }
}
