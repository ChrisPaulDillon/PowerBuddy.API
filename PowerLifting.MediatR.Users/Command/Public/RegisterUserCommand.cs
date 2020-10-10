using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.DTOs.Users;

namespace PowerLifting.MediatR.Users.Command.Public
{
    public class RegisterUserCommand : IRequest<bool>
    {
        public RegisterUserDTO RegisterUserDTO { get; }

        public RegisterUserCommand(RegisterUserDTO registerUserDTO)
        {
            RegisterUserDTO = registerUserDTO;
        }
    }
}
