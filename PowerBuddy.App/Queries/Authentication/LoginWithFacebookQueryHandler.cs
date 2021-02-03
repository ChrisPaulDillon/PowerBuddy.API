﻿using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.App.Services.Authentication;
using PowerBuddy.App.Services.Authentication.Models;
using PowerBuddy.AuthenticationService;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.App.Queries.Authentication
{
    public class LoginWithFacebookQuery : IRequest<AuthenticationResultDTO>
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
            RuleFor(x => x.AccessToken).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
        }
    }

    internal class LoginWithFacebookQueryHandler : IRequestHandler<LoginWithFacebookQuery, AuthenticationResultDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly IFacebookAuthService _facebookAuthService;
        private readonly ITokenService _tokenService;
        private readonly UserManager<User> _userManager;

        public LoginWithFacebookQueryHandler(PowerLiftingContext context, IMapper mapper, IFacebookAuthService facebookAuthService, ITokenService tokenService, UserManager<User> userManager)
        {
            _context = context;
            _mapper = mapper;
            _facebookAuthService = facebookAuthService;
            _tokenService = tokenService;
            _userManager = userManager;
        }

        public async Task<AuthenticationResultDTO> Handle(LoginWithFacebookQuery request, CancellationToken cancellationToken)
        {
            var validationTokenResult = await _facebookAuthService.ValidateAccessTokenAsync(request.AccessToken);

            if (!validationTokenResult.Data.IsValid)
            {

            }

            var userInfo = await _facebookAuthService.GetUserInfoAsync(request.AccessToken);

            var user = await _context.User.AsNoTracking().FirstOrDefaultAsync(x => x.NormalizedEmail.Equals(userInfo.Email));

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