using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.DTOs.Users;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Exceptions.Account;
using PowerBuddy.Services.Account;

namespace PowerBuddy.MediatR.Users.Commands
{
    public class RegisterUserCommand : IRequest<string>
    {
        public RegisterUserDTO RegisterUserDTO { get; }

        public RegisterUserCommand(RegisterUserDTO registerUserDTO)
        {
            RegisterUserDTO = registerUserDTO;
            new RegisterUserCommandValidator().ValidateAndThrow(this);
        }
    }

    internal class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(x => x.RegisterUserDTO.UserName).NotNull().NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.RegisterUserDTO.Email).NotNull().NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.RegisterUserDTO.Password).NotNull().NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
        }
    }

    internal class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, string>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IAccountService _accountService;

        public RegisterUserCommandHandler(PowerLiftingContext context, IMapper mapper, UserManager<User> userManager, IAccountService accountService)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _accountService = accountService;
        }

        public async Task<string> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var doesUserExist = await _context.User
                .AsNoTracking()
                .AnyAsync(x => x.Email == request.RegisterUserDTO.Email || x.NormalizedUserName == request.RegisterUserDTO.UserName.ToUpper());

            if (doesUserExist) throw new EmailOrUserNameInUseException();

            request.RegisterUserDTO.SportType = "PowerLifting";

            var userEntity = _mapper.Map<User>(request.RegisterUserDTO);
            userEntity.MemberStatusId = 1;

            userEntity.UserSetting = new UserSetting()
            {
                UserId = userEntity.Id
            };

            var result = await _userManager.CreateAsync(userEntity, request.RegisterUserDTO.Password);

            userEntity = null;

            if (result.Succeeded)
            {
                return userEntity.Id;
            }

            return null;
        }
    }
}