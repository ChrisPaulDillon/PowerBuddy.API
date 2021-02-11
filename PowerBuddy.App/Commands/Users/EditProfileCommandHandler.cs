using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OneOf;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Dtos.Account;
using PowerBuddy.Data.Models.Account;
using PowerBuddy.Util;

namespace PowerBuddy.App.Commands.Users
{
    public class EditProfileCommand : IRequest<OneOf<bool, UserNotFound>>
    {
        public EditProfileDto EditProfileDto { get; }
        public string UserId { get; }

        public EditProfileCommand(EditProfileDto editProfileDto, string userId)
        {
            EditProfileDto = editProfileDto;
            UserId = userId;
        }
    }

    public class EditProfileCommandValidator : AbstractValidator<EditProfileCommand>
    {
        public EditProfileCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage(ValidationConstants.NOT_EMPTY);
            RuleFor(x => x.EditProfileDto.QuotesEnabled).NotNull().WithMessage(ValidationConstants.NOT_NULL);
        }
    }

    public class EditProfileCommandHandler : IRequestHandler<EditProfileCommand, OneOf<bool, UserNotFound>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public EditProfileCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OneOf<bool, UserNotFound>> Handle(EditProfileCommand request, CancellationToken cancellationToken)
        {
            if (request.UserId != request.EditProfileDto.UserId)
            {
                return new UserNotFound();
            }

            var user = await _context.User
                .Include(x => x.UserSetting)
                .FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken: cancellationToken);

            if (user == null)
            {
                return new UserNotFound();
            }

            var updatedProfile = _mapper.Map(request.EditProfileDto, user);
            updatedProfile.UserSetting = _mapper.Map(request.EditProfileDto, updatedProfile.UserSetting);
            _context.User.Update(updatedProfile);

            var modifiedRows = await _context.SaveChangesAsync(cancellationToken);
            return modifiedRows > 0;
        }
    }
}
