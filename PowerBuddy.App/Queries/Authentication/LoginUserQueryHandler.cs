using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OneOf;
using PowerBuddy.App.Queries.Authentication.Models;
using PowerBuddy.App.Services.Authentication;
using PowerBuddy.App.Services.Authentication.Models;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Dtos.Users;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Models.Account;
using PowerBuddy.Util;

namespace PowerBuddy.App.Queries.Authentication
{
    public class LoginUserQuery : IRequest<OneOf<AuthenticationResultDto, UserNotFound, EmailNotConfirmed, AccountLockout, InvalidCredentials>>
    {
        public LoginRequestModel LoginModel { get; }

        public LoginUserQuery(LoginRequestModel loginModel)
        {
            LoginModel = loginModel;
        }
    }

    public class LoginUserQueryValidator : AbstractValidator<LoginUserQuery>
    {
        public LoginUserQueryValidator()
        {
            RuleFor(x => x.LoginModel.UserName).NotEmpty().WithMessage(ValidationConstants.NOT_EMPTY);
            RuleFor(x => x.LoginModel.Email).NotEmpty().WithMessage(ValidationConstants.NOT_EMPTY);
            RuleFor(x => x.LoginModel.Password).NotEmpty().WithMessage(ValidationConstants.NOT_EMPTY);
        }
    }

    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, OneOf<AuthenticationResultDto, UserNotFound, EmailNotConfirmed, AccountLockout, InvalidCredentials>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;

        public LoginUserQueryHandler(PowerLiftingContext context, IMapper mapper, SignInManager<User> signInManager, ITokenService tokenService)
        {
            _context = context;
            _mapper = mapper;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<OneOf<AuthenticationResultDto, UserNotFound, EmailNotConfirmed, AccountLockout, InvalidCredentials>> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.User
	            .FirstOrDefaultAsync(x => x.NormalizedEmail == request.LoginModel.Email.ToUpper() || x.NormalizedUserName == request.LoginModel.UserName.ToUpper(), cancellationToken: cancellationToken);

            if (user == null)
            {
                return new UserNotFound();
            }

            if (!user.EmailConfirmed)
            {
                return new EmailNotConfirmed(user.Id);
            }

            var result = await _signInManager.PasswordSignInAsync(user, request.LoginModel.Password, true, true);

            if (result.IsLockedOut)
            {
	            return new AccountLockout();
            }

            if (result.Succeeded)
            {
                var authenticatedUser = await _tokenService.CreateRefreshTokenAuthenticationResult(user.Id, _mapper.Map<UserDto>(user));
                return authenticatedUser;
            }

            return new InvalidCredentials();
        }
    }
}