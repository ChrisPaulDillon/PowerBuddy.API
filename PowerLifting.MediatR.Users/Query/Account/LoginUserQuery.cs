using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.Entities.Account;

namespace PowerLifting.MediatR.Users.Query.Account
{
    public class LoginUserQuery : IRequest<string>
    {
        public LoginModel LoginModel { get; }

        public LoginUserQuery(LoginModel loginModel)
        {
            LoginModel = loginModel;
        }
    }
}
