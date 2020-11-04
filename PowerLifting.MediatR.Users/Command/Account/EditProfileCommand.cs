using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.DTOs.Users;

namespace PowerLifting.MediatR.Users.Command.Account
{
    public class EditProfileCommand : IRequest<bool>
    {
        public EditProfileDTO EditProfileDTO { get; }
        public string UserId { get; }

        public EditProfileCommand(EditProfileDTO editProfileDTO, string userId)
        {
            EditProfileDTO = editProfileDTO;
            UserId = userId;
        }
    }
}
