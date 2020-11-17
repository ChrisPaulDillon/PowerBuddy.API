using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Context;
using PowerBuddy.Data.DTOs.Users;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Exceptions.Account;

namespace PowerBuddy.MediatR.Users.Commands.Public
{
    public class RegisterUserCommand : IRequest<bool>
    {
        public RegisterUserDTO RegisterUserDTO { get; }

        public RegisterUserCommand(RegisterUserDTO registerUserDTO)
        {
            RegisterUserDTO = registerUserDTO;
            new RegisterUserCommandValidator().ValidateAndThrow(this);
        }
    }

    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(x => x.RegisterUserDTO.UserName).NotNull().NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.RegisterUserDTO.Email).NotNull().NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.RegisterUserDTO.Password).NotNull().NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
        }
    }

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
            //if (!Enum.IsDefined(typeof(SportEnum), request.RegisterUserDTO.SportType.ToUpper())) throw new UserValidationException("Incorrect Sport");

            var doesUserExist = await _context.User.AsNoTracking().AnyAsync(x => x.Email == request.RegisterUserDTO.Email || x.NormalizedUserName == request.RegisterUserDTO.UserName.ToUpper(), cancellationToken: cancellationToken);
            if (doesUserExist) throw new EmailOrUserNameInUseException();

            request.RegisterUserDTO.SportType = "PowerLifting";

            var userEntity = _mapper.Map<User>(request.RegisterUserDTO);
            userEntity.MemberStatusId = 1;

            userEntity.UserSetting = new UserSetting()
            {
                UserId = userEntity.Id
            };

            var result = await _userManager.CreateAsync(userEntity, request.RegisterUserDTO.Password);
            return result.Succeeded;
        }
    }
}