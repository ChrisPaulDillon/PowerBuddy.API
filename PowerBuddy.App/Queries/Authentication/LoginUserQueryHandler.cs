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
using PowerBuddy.Data.DTOs.Users;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Models.Account;

namespace PowerBuddy.App.Queries.Authentication
{
    public class LoginUserQuery : IRequest<OneOf<AuthenticationResultDTO, UserNotFound, EmailNotConfirmed, AccountLockout, InvalidCredentials>>
    {
        public LoginModelDTO LoginModel { get; }

        public LoginUserQuery(LoginModelDTO loginModel)
        {
            LoginModel = loginModel;
        }
    }

    public class LoginUserQueryValidator : AbstractValidator<LoginUserQuery>
    {
        public LoginUserQueryValidator()
        {
            RuleFor(x => x.LoginModel.UserName).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.LoginModel.Email).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.LoginModel.Password).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
        }
    }

    internal class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, OneOf<AuthenticationResultDTO, UserNotFound, EmailNotConfirmed, AccountLockout, InvalidCredentials>>
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

        public async Task<OneOf<AuthenticationResultDTO, UserNotFound, EmailNotConfirmed, AccountLockout, InvalidCredentials>> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.User
	            .FirstOrDefaultAsync(x => x.NormalizedEmail == request.LoginModel.Email.ToUpper() || x.NormalizedUserName == request.LoginModel.UserName.ToUpper());

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
                var authenticatedUser = await _tokenService.CreateRefreshTokenAuthenticationResult(user.Id, _mapper.Map<UserDTO>(user));
                return authenticatedUser;
            }

            return new InvalidCredentials();
        }
    }
}