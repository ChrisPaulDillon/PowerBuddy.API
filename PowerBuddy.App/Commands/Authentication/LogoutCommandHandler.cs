using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using PowerBuddy.App.Services.Authentication;
using PowerBuddy.Data.Context;
using PowerBuddy.Util;

namespace PowerBuddy.App.Commands.Authentication
{
    public class LogoutCommand : IRequest<bool>
    {
        public string RefreshToken { get; }

        public LogoutCommand(string refreshToken)
        {
            RefreshToken = refreshToken;
        }
    }

    public class LogoutCommandValidator : AbstractValidator<LogoutCommand>
    {
        public LogoutCommandValidator()
        {
            RuleFor(x => x.RefreshToken).NotEmpty().WithMessage(ValidationConstants.NOT_EMPTY);
        }
    }

    public class LogoutCommandHandler : IRequestHandler<LogoutCommand, bool>
    {
        private readonly ITokenService _tokenService;

        public LogoutCommandHandler(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public async Task<bool> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            return await _tokenService.RevokeRefreshTokenAsync(request.RefreshToken);
        }
    }
}