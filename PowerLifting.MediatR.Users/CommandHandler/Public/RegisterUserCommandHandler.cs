using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.Entities.Account;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.MediatR.Users.Command.Public;
using PowerLifting.MediatR.Users.Query.Account;
using PowerLifting.Persistence;

namespace PowerLifting.MediatR.Users.CommandHandler.Public
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, bool>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        public RegisterUserCommandHandler(PowerLiftingContext context, IMapper mapper, UserManager<User> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.RegisterUserDTO.Email)) throw new UserValidationException("Email cannot be empty");
            if (string.IsNullOrEmpty(request.RegisterUserDTO.Password)) throw new UserValidationException("Password cannot be empty");
            if (string.IsNullOrEmpty(request.RegisterUserDTO.UserName)) throw new UserValidationException("UserName cannot be empty");

            var doesUserExist = await _context.User.AsNoTracking().AnyAsync(x => x.Email == request.RegisterUserDTO.Email || x.NormalizedUserName == request.RegisterUserDTO.UserName.ToUpper());
            if (doesUserExist) throw new EmailOrUserNameInUseException();

            var userEntity = _mapper.Map<User>(request.RegisterUserDTO);

            userEntity.UserSetting = new UserSetting()
            {
                UserId = userEntity.Id
            };

            var result = await _userManager.CreateAsync(userEntity, request.RegisterUserDTO.Password);
            return result.Succeeded;
        }
    }
}