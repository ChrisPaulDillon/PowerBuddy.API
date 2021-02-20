using System;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.Data.Builders.Entities.Account
{
    public class UserBuilder
    {
        private readonly Random _random;
        private readonly User _user;

        public UserBuilder(Random random = null)
        {
            _random = random ?? new Random();
            var userName = _random.Next().ToString();
            var email = _random.Next().ToString();

            _user = new User
            {
                Id = _random.Next().ToString(),
                UserName = userName,
                NormalizedUserName = userName.ToUpper(),
                Email = email,
                NormalizedEmail = email.ToUpper(),
                PasswordHash = _random.Next().ToString(),
                MemberStatusId = 1,
                IsPublic = true
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

        public UserBuilder WithEmail(string email)
        {
            _user.Email = email;
            return this;
        }

        public UserBuilder WithNormalizedEmail(string normalizedEmail)
        {
            _user.NormalizedEmail = normalizedEmail;
            return this;
        }

        public UserBuilder WithUserName(string userName)
        {
            _user.UserName = userName;
            return this;
        }

        public UserBuilder WithNormalizedUserName(string userName)
        {
            _user.NormalizedUserName = userName;
            return this;
        }

        public UserBuilder WithMemberStatusId(int memberId)
        {
            _user.MemberStatusId = memberId;
            return this;
        }

        public UserBuilder WithIsPublic(bool isPublic)
        {
	        _user.IsPublic = isPublic;
	        return this;
        }
    }
}
