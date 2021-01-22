using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Util;
using PowerBuddy.ExternalLoginProviderService;
using PowerBuddy.MediatR.Authentication.Models;

namespace PowerBuddy.MediatR.Authentication.Querys
{
    public class LoginWithFacebookQuery : IRequest<UserLoggedInDTO>
    {
        public string AccessToken { get; }

        public LoginWithFacebookQuery(string accessToken)
        {
            AccessToken = accessToken;
            new LoginWithFacebookQueryValidator().ValidateAndThrow(this);
        }
    }

    internal class LoginWithFacebookQueryValidator : AbstractValidator<LoginWithFacebookQuery>
    {
        public LoginWithFacebookQueryValidator()
        {
            RuleFor(x => x.AccessToken).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
        }
    }

    internal class LoginWithFacebookQueryHandler : IRequestHandler<LoginWithFacebookQuery, UserLoggedInDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly SignInManager<User> _signInManager;
        private readonly JWTSettings _jwtSettings;
        private readonly IFacebookAuthService _facebookAuthService;
        private readonly UserManager<User> _userManager;

        public LoginWithFacebookQueryHandler(PowerLiftingContext context, IMapper mapper, SignInManager<User> signInManager, JWTSettings jwtSettings, IFacebookAuthService facebookAuthService, UserManager<User> userManager)
        {
            _context = context;
            _mapper = mapper;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings;
            _facebookAuthService = facebookAuthService;
            _userManager = userManager;
        }

        public async Task<UserLoggedInDTO> Handle(LoginWithFacebookQuery request, CancellationToken cancellationToken)
        {
            var validationTokenResult = await _facebookAuthService.ValidateAccessTokenAsync(request.AccessToken);

            if (!validationTokenResult.Data.IsValid)
            {

            }

            var userInfo = await _facebookAuthService.GetUserInfoAsync(request.AccessToken);

            var user = await _context.User.AsNoTracking().FirstOrDefaultAsync(x => x.NormalizedEmail.Equals(userInfo.Email));

            if (user == null)
            {
                var firstTimeUser = new User()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = userInfo.Email,
                    UserName = userInfo.Email
                };

                var createdResult = await _userManager.CreateAsync(firstTimeUser);

                if (createdResult.Succeeded)
                {

                }
            }
        }
    }
}