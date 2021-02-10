using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Models.Account;
using PowerBuddy.FileHandlerService.Services;
using OneOf;

namespace PowerBuddy.App.Commands.Users
{
    public class UploadProfileImageCommand : IRequest<OneOf<bool, UserNotFound>>
    {
        public IFormFile ImageFile { get; }
        public string UserId { get; }

        public UploadProfileImageCommand(IFormFile imageFile, string userId)
        {
            ImageFile = imageFile;
            UserId = userId;
        }
    }

    public class UploadProfileImageCommandValidator : AbstractValidator<UploadProfileImageCommand>
    {
        public UploadProfileImageCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
        }
    }

    public class UploadProfileImageCommandHandler : IRequestHandler<UploadProfileImageCommand, OneOf<bool, UserNotFound>>
    {
        private readonly PowerLiftingContext _context;
        private readonly ImageFileHandlerService _fileHandler;

        public UploadProfileImageCommandHandler(PowerLiftingContext context, ImageFileHandlerService fileHandler)
        {
            _context = context;
            _fileHandler = fileHandler;
        }

        public async Task<OneOf<bool, UserNotFound>> Handle(UploadProfileImageCommand request, CancellationToken cancellationToken)
        {
            var convertedImage = _fileHandler.ConvertFile(request.ImageFile, out var fileName);

            var user = await _context.User.FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken: cancellationToken);

            if (user == null)
            {
                return new UserNotFound();
            }

            user.ProfileImageName = fileName;
            user.ProfileImageData = convertedImage;

            var modifiedRows = await _context.SaveChangesAsync(cancellationToken);
            return modifiedRows > 0;
        }
    }
}
