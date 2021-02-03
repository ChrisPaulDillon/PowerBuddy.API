using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OneOf;
using PowerBuddy.App.Services.Authentication;
using PowerBuddy.App.Services.Authentication.Models;
using PowerBuddy.AuthenticationService;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Models.Auth;

namespace PowerBuddy.App.Commands.Authentication
{
    public class RefreshTokenCommand : IRequest<OneOf<AuthenticationResultDTO, RefreshTokenNotFound, InvalidRefreshToken>>
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

    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, OneOf<AuthenticationResultDTO, RefreshTokenNotFound, InvalidRefreshToken>>
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

        public async Task<OneOf<AuthenticationResultDTO, RefreshTokenNotFound, InvalidRefreshToken>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var refreshToken = await _context.RefreshToken.FirstOrDefaultAsync(x => x.Token == request.RefreshToken);

            if (refreshToken == null)
            {
                return new RefreshTokenNotFound("Refresh Token does not exist");
            }

            if (DateTime.UtcNow > refreshToken.ExpiryDate)
            {
                return new InvalidRefreshToken("Refresh Token has expired");
            }

            if (refreshToken.Invalidated)
            {
                return new InvalidRefreshToken("Refresh Token has been invalidated");
            }

            if (refreshToken.IsUsed)
            {
                return new InvalidRefreshToken("Refresh token has been used");
            }

            refreshToken.IsUsed = true;
            await _context.SaveChangesAsync();

            var authenticatedUser = await _tokenService.CreateRefreshTokenAuthenticationResult(refreshToken.UserId, null);

            return authenticatedUser;
        }
    }
}