using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OneOf;
using PowerBuddy.App.Commands.Authentication.Models;
using PowerBuddy.App.Services.Authentication;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Dtos.Users;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Models.Account;
using PowerBuddy.Data.Requests.Users;
using PowerBuddy.Util;

namespace PowerBuddy.App.Commands.Authentication
{
    public class RegisterUserCommand : IRequest<OneOf<RegisterAuthenticationResultDto, EmailOrUserNameInUse>>
    {
        public RegisterUserRequest RegisterUserDto { get; }

        public RegisterUserCommand(RegisterUserRequest registerUserDto)
        {
            RegisterUserDto = registerUserDto;
        }
    }

    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(x => x.RegisterUserDto.UserName).NotEmpty().WithMessage(ValidationConstants.NOT_EMPTY);
            RuleFor(x => x.RegisterUserDto.Email).NotEmpty().WithMessage(ValidationConstants.NOT_EMPTY);
            RuleFor(x => x.RegisterUserDto.Password).NotEmpty().WithMessage(ValidationConstants.NOT_EMPTY);
        }
    }

    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, OneOf<RegisterAuthenticationResultDto, EmailOrUserNameInUse>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;

        public RegisterUserCommandHandler(PowerLiftingContext context, IMapper mapper, UserManager<User> userManager, ITokenService tokenService)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<OneOf<RegisterAuthenticationResultDto, EmailOrUserNameInUse>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var doesUserExist = await _context.User
                .AsNoTracking()
                .AnyAsync(x => x.NormalizedEmail == request.RegisterUserDto.Email.ToUpper() || x.NormalizedUserName == request.RegisterUserDto.UserName.ToUpper(), cancellationToken: cancellationToken);

            if (doesUserExist)
            {
	            return new EmailOrUserNameInUse();
            }

            request.RegisterUserDto.SportType = "PowerLifting";

            var userEntity = _mapper.Map<User>(request.RegisterUserDto);
            userEntity.MemberStatusId = 1;

            userEntity.UserSetting = new UserSetting()
            {
                UserId = userEntity.Id,
                UsingMetric = true
            };

            var result = await _userManager.CreateAsync(userEntity, request.RegisterUserDto.Password);

            if (result.Succeeded)
            {
                var authenticatedUser = await _tokenService.CreateRefreshTokenAuthenticationResult(userEntity.Id, _mapper.Map<UserDto>(userEntity));
                var registeredAuthenticationResult = new RegisterAuthenticationResultDto()
                {
                    AccessToken = authenticatedUser.AccessToken,
                    RefreshToken = authenticatedUser.RefreshToken,
                    UserId = userEntity.Id
                };
                return registeredAuthenticationResult;
            }

            return null;
        }
    }
}