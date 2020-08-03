using PowerLifting.Data.Entities.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerLifting.Data.Builders.Account
{
    public class UserBuilder
    {
        private readonly Random _random;
        private readonly User _user;

        public UserBuilder(Random random = null)
        {
            _random = random ?? new Random();
            _user = new User
            {
                Id = _random.Next().ToString(),
                UserName = _random.Next().ToString(),
                Email = _random.Next().ToString(),
                Rights = 0
            };
        }

        public User Build()
        {
            return _user;
        }

        public UserBuilder WithUserId(string userId)
        {
            _user.Id = userId;
            return this;
        }

        public UserBuilder WithUserName(string userName)
        {
            _user.UserName = userName;
            return this;
        }

        public UserBuilder WithRights(int rights)
        {
            _user.Rights = rights;
            return this;
        }
    }
}
