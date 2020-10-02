using MediatR;
using PowerLifting.MediatR.Users.Models;

namespace PowerLifting.MediatR.Users.Query.Account
{
    public class LoginUserQuery : IRequest<UserLoggedInDTO>
    {
        public LoginModelDTO LoginModel { get; }

        public LoginUserQuery(LoginModelDTO loginModel)
        {
            LoginModel = loginModel;
        }
    }
}
