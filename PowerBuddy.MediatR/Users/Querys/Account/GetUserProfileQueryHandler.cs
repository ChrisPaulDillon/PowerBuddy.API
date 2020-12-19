﻿using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.DTOs.Users;
using PowerBuddy.Data.Exceptions.Account;

namespace PowerBuddy.MediatR.Users.Querys.Account
{
    public class GetUserProfileQuery : IRequest<UserDTO>
    {
        public string UserId { get; }

        public GetUserProfileQuery(string userId)
        {
            UserId = userId;
            new GetUserProfileQueryValidator().ValidateAndThrow(this);
        }
    }

    public class GetUserProfileQueryValidator : AbstractValidator<GetUserProfileQuery>
    {
        public GetUserProfileQueryValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
        }
    }

    public class GetUserProfileQueryHandler : IRequestHandler<GetUserProfileQuery, UserDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public GetUserProfileQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserDTO> Handle(GetUserProfileQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.UserId)) throw new UserValidationException("UserId cannot be empty");

            var user = await _context.User
                .Where(x => x.Id == request.UserId)
                .AsNoTracking()
                .ProjectTo<UserDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (user == null) throw new UserNotFoundException();

            user.UserSetting = await _context.UserSetting
                .AsNoTracking()
                .ProjectTo<UserSettingDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.UserId == request.UserId, cancellationToken: cancellationToken);

            return user;
        }
    }
}
