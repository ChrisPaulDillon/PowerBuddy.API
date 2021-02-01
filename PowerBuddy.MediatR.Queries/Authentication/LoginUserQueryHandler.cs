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
using PowerBuddy.MediatR.Queries.Authentication.Models;
using PowerBuddy.Services.Authentication;
using PowerBuddy.Services.Authentication.Models;

namespace PowerBuddy.MediatR.Queries.Authentication
{
    public class LoginUserQuery : IRequest<AuthenticationResultDTO>
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

    internal class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, AuthenticationResultDTO>
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

        public async Task<AuthenticationResultDTO> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.User
	            .FirstOrDefaultAsync(x => x.NormalizedEmail == request.LoginModel.Email.ToUpper() || x.NormalizedUserName == request.LoginModel.UserName.ToUpper());

            if (user == null)
            {
                throw new UserNotFoundException();
            }

            if (!user.EmailConfirmed)
            {
                throw new EmailNotConfirmedException(user.Id);
            }

            var result = await _signInManager.PasswordSignInAsync(user, request.LoginModel.Password, true, true);

            if (result.IsLockedOut)
            {
	            throw new AccountLockoutException();
            }

            if (result.Succeeded)
            {
                var authenticatedUser = await _tokenService.CreateRefreshTokenAuthenticationResult(user.Id, _mapper.Map<UserDTO>(user));
                return authenticatedUser;
            }

            throw new InvalidCredentialsException();
        }
    }
}