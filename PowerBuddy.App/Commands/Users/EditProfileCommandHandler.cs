using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OneOf;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.DTOs.Account;
using PowerBuddy.Data.Models.Account;

namespace PowerBuddy.App.Commands.Users
{
    public class EditProfileCommand : IRequest<OneOf<bool, UserNotFound>>
    {
        public EditProfileDTO EditProfileDTO { get; }
        public string UserId { get; }

        public EditProfileCommand(EditProfileDTO editProfileDTO, string userId)
        {
            EditProfileDTO = editProfileDTO;
            UserId = userId;
        }
    }

    public class EditProfileCommandValidator : AbstractValidator<EditProfileCommand>
    {
        public EditProfileCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.EditProfileDTO.QuotesEnabled).NotNull().WithMessage("'{PropertyName}' cannot be null.");
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
            if (request.UserId != request.EditProfileDTO.UserId)
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

            var updatedProfile = _mapper.Map(request.EditProfileDTO, user);
            updatedProfile.UserSetting = _mapper.Map(request.EditProfileDTO, updatedProfile.UserSetting);
            _context.User.Update(updatedProfile);

            var modifiedRows = await _context.SaveChangesAsync(cancellationToken);
            return modifiedRows > 0;
        }
    }
}
