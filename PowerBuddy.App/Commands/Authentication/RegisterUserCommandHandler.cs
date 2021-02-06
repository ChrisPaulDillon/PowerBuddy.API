﻿using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OneOf;
using PowerBuddy.App.Commands.Authentication.Models;
using PowerBuddy.App.Services.Authentication;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.DTOs.Users;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Models.Account;

namespace PowerBuddy.App.Commands.Authentication
{
    public class RegisterUserCommand : IRequest<OneOf<RegisterAuthenticationResultDTO, EmailOrUserNameInUse>>
    {
        public RegisterUserDTO RegisterUserDTO { get; }

        public RegisterUserCommand(RegisterUserDTO registerUserDTO)
        {
            RegisterUserDTO = registerUserDTO;
        }
    }

    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(x => x.RegisterUserDTO.UserName).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.RegisterUserDTO.Email).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.RegisterUserDTO.Password).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
        }
    }

    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, OneOf<RegisterAuthenticationResultDTO, EmailOrUserNameInUse>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;

        public RegisterUserCommandHandler(PowerLiftingContext context, IMapper mapper, UserManager<User> userManager, ITokenService tokenService)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<OneOf<RegisterAuthenticationResultDTO, EmailOrUserNameInUse>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var doesUserExist = await _context.User
                .AsNoTracking()
                .AnyAsync(x => x.NormalizedEmail == request.RegisterUserDTO.Email.ToUpper() || x.NormalizedUserName == request.RegisterUserDTO.UserName.ToUpper(), cancellationToken: cancellationToken);

            if (doesUserExist)
            {
	            return new EmailOrUserNameInUse();
            }

            request.RegisterUserDTO.SportType = "PowerLifting";

            var userEntity = _mapper.Map<User>(request.RegisterUserDTO);
            userEntity.MemberStatusId = 1;

            userEntity.UserSetting = new UserSetting()
            {
                UserId = userEntity.Id,
                UsingMetric = true
            };

            var result = await _userManager.CreateAsync(userEntity, request.RegisterUserDTO.Password);

            if (result.Succeeded)
            {
                var authenticatedUser = await _tokenService.CreateRefreshTokenAuthenticationResult(userEntity.Id, _mapper.Map<UserDTO>(_mapper.ConfigurationProvider));
                var registeredAuthenticationResult = new RegisterAuthenticationResultDTO()
                {
                    AccessToken = authenticatedUser.AccessToken,
                    RefreshToken = authenticatedUser.RefreshToken,
                    UserId = userEntity.Id
                };
                return registeredAuthenticationResult;
            }

            return null;
        }
    }
}