using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.MediatR.Authentication.Exceptions;
using PowerBuddy.Services.Authentication;
using PowerBuddy.Services.Authentication.Models;

namespace PowerBuddy.MediatR.Authentication.Commands
{
    public class RefreshTokenCommand : IRequest<AuthenticatedUserDTO>
    {
        public string AccessToken { get; }
        public string RefreshToken { get; }

        public RefreshTokenCommand(string accessToken, string refreshToken)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            new RefreshTokenCommandValidator().ValidateAndThrow(this);
        }
    }

    internal class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommand>
    {
        public RefreshTokenCommandValidator()
        {
            RuleFor(x => x.RefreshToken).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.AccessToken).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
        }
    }

    internal class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, AuthenticatedUserDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public RefreshTokenCommandHandler(PowerLiftingContext context, IMapper mapper, ITokenService tokenService)
        {
            _context = context;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public async Task<AuthenticatedUserDTO> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
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

            var authenticatedUser = await _tokenService.CreateRefreshTokenAuthenticationResult(refreshToken.UserId);

            return authenticatedUser;
        }
    }
}