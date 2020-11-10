﻿using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.Exceptions.Account;

namespace PowerLifting.MediatR.Users.Commands.Account
{
    public class EditProfileCommand : IRequest<bool>
    {
        public EditProfileDTO EditProfileDTO { get; }
        public string UserId { get; }

        public EditProfileCommand(EditProfileDTO editProfileDTO, string userId)
        {
            EditProfileDTO = editProfileDTO;
            UserId = userId;
            new EditProfileCommandValidator().ValidateAndThrow(this);
        }
    }

    public class EditProfileCommandValidator : AbstractValidator<EditProfileCommand>
    {
        public EditProfileCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.EditProfileDTO.BodyWeight).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than {ComparisonValue}.");
            RuleFor(x => x.EditProfileDTO.QuotesEnabled).NotNull().NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
        }
    }

    public class EditProfileCommandHandler : IRequestHandler<EditProfileCommand, bool>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public EditProfileCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(EditProfileCommand request, CancellationToken cancellationToken)
        {
            if (request.UserId != request.EditProfileDTO.UserId) throw new UnauthorisedUserException();

            var user = await _context.User.Include(x => x.UserSetting).FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken: cancellationToken);

            if (user == null) throw new UserNotFoundException();

            var updatedProfile = _mapper.Map(request.EditProfileDTO, user);
            updatedProfile.UserSetting = _mapper.Map(request.EditProfileDTO, updatedProfile.UserSetting);
            _context.User.Update(updatedProfile);

            var modifiedRows = await _context.SaveChangesAsync(cancellationToken);
            return modifiedRows > 0;
        }
    }
}