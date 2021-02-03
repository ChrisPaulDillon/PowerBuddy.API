﻿using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.App.Commands.Authentication.Exceptions;
using PowerBuddy.App.Services.Authentication;
using PowerBuddy.App.Services.Authentication.Models;
using PowerBuddy.AuthenticationService;
using PowerBuddy.Data.Context;

namespace PowerBuddy.App.Commands.Authentication
{
    public class RefreshTokenCommand : IRequest<AuthenticationResultDTO>
    {
        public string RefreshToken { get; }

        public RefreshTokenCommand(string refreshToken)
        {
            RefreshToken = refreshToken;
        }
    }

    public class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommand>
    {
        public RefreshTokenCommandValidator()
        {
            RuleFor(x => x.RefreshToken).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
        }
    }

    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, AuthenticationResultDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly IAuthService _authService;

        public RefreshTokenCommandHandler(PowerLiftingContext context, IMapper mapper, ITokenService tokenService, IAuthService authService)
        {
            _context = context;
            _mapper = mapper;
            _tokenService = tokenService;
            _authService = authService;
        }

        public async Task<AuthenticationResultDTO> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var refreshToken = await _context.RefreshToken.FirstOrDefaultAsync(x => x.Token == request.RefreshToken);

            if (refreshToken == null)
            {
                throw new RefreshTokenNotFoundException("Refresh Token does not exist");
            }

            if (DateTime.UtcNow > refreshToken.ExpiryDate)
            {
                throw new InvalidRefreshTokenException("Refresh Token has expired");
            }

            if (refreshToken.Invalidated)
            {
                throw new InvalidRefreshTokenException("Refresh Token has been invalidated");
            }

            if (refreshToken.IsUsed)
            {
                throw new InvalidRefreshTokenException("Refresh token has been used");
            }

            refreshToken.IsUsed = true;
            await _context.SaveChangesAsync();

            var authenticatedUser = await _tokenService.CreateRefreshTokenAuthenticationResult(refreshToken.UserId, null);

            return authenticatedUser;
        }
    }
}