﻿using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using PowerBuddy.Data.Context;
using PowerBuddy.Services.Authentication;

namespace PowerBuddy.MediatR.Commands.Authentication
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
            RuleFor(x => x.RefreshToken).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
        }
    }

    public class LogoutCommandHandler : IRequestHandler<LogoutCommand, bool>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public LogoutCommandHandler(PowerLiftingContext context, IMapper mapper, ITokenService tokenService)
        {
            _context = context;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public async Task<bool> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            return await _tokenService.RevokeRefreshTokenAsync(request.RefreshToken);
        }
    }
}