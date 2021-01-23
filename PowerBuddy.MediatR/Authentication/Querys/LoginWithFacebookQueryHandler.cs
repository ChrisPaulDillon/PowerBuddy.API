﻿using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.AuthenticationService;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.DTOs.Users;
using PowerBuddy.Data.Entities;
using PowerBuddy.MediatR.Authentication.Models;
using PowerBuddy.Services.Authentication.Models;

namespace PowerBuddy.MediatR.Authentication.Querys
{
    public class LoginWithFacebookQuery : IRequest<AuthenticatedUserDTO>
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

    internal class LoginWithFacebookQueryHandler : IRequestHandler<LoginWithFacebookQuery, AuthenticatedUserDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly IFacebookAuthService _facebookAuthService;
        private readonly IAuthService _authService;
        private readonly UserManager<User> _userManager;

        public LoginWithFacebookQueryHandler(PowerLiftingContext context, IMapper mapper, IFacebookAuthService facebookAuthService, IAuthService authService, UserManager<User> userManager)
        {
            _context = context;
            _mapper = mapper;
            _facebookAuthService = facebookAuthService;
            _authService = authService;
            _userManager = userManager;
        }

        public async Task<AuthenticatedUserDTO> Handle(LoginWithFacebookQuery request, CancellationToken cancellationToken)
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

            var jwtToken = _authService.GenerateJwtToken(user.Id);

            var userExtended = new AuthenticatedUserDTO()
            {
                User = _mapper.Map<UserDTO>(user),
                AccessToken = jwtToken
            };

            return userExtended;
        }
    }
}