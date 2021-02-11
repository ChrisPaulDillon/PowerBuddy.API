using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.App.Services.Authentication;
using PowerBuddy.App.Services.Authentication.Models;
using PowerBuddy.AuthenticationService;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Entities;
using PowerBuddy.Util;

namespace PowerBuddy.App.Queries.Authentication
{
    public class LoginWithFacebookQuery : IRequest<AuthenticationResultDto>
    {
        public string AccessToken { get; }

        public LoginWithFacebookQuery(string accessToken)
        {
            AccessToken = accessToken;
        }
    }

    public class LoginWithFacebookQueryValidator : AbstractValidator<LoginWithFacebookQuery>
    {
        public LoginWithFacebookQueryValidator()
        {
            RuleFor(x => x.AccessToken).NotEmpty().WithMessage(ValidationConstants.NOT_EMPTY);
        }
    }

    internal class LoginWithFacebookQueryHandler : IRequestHandler<LoginWithFacebookQuery, AuthenticationResultDto>
    {
        private readonly PowerLiftingContext _context;
        private readonly IFacebookAuthService _facebookAuthService;
        private readonly ITokenService _tokenService;
        private readonly UserManager<User> _userManager;

        public LoginWithFacebookQueryHandler(PowerLiftingContext context, IFacebookAuthService facebookAuthService, ITokenService tokenService, UserManager<User> userManager)
        {
            _context = context;
            _facebookAuthService = facebookAuthService;
            _tokenService = tokenService;
            _userManager = userManager;
        }

        public async Task<AuthenticationResultDto> Handle(LoginWithFacebookQuery request, CancellationToken cancellationToken)
        {
            var userInfo = await _facebookAuthService.GetUserInfoAsync(request.AccessToken);

            var user = await _context.User.AsNoTracking().FirstOrDefaultAsync(x => x.NormalizedEmail.Equals(userInfo.Email), cancellationToken: cancellationToken);

            if (user == null)
            {
                user = new User()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = userInfo.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                };

                var createdResult = await _userManager.CreateAsync(user);
            }

            var authenticatedUser = await _tokenService.CreateRefreshTokenAuthenticationResult(user.Id, null);

            return authenticatedUser;
        }
    }
}