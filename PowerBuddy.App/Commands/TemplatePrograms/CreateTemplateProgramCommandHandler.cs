using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OneOf;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Dtos.Templates;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Models.Account;
using PowerBuddy.Data.Models.TemplatePrograms;
using PowerBuddy.Util;

namespace PowerBuddy.App.Commands.TemplatePrograms
{
    public class CreateTemplateProgramCommand : IRequest<OneOf<TemplateProgramDto, UserNotFound, TemplateProgramNameAlreadyExists>>
    {
        public TemplateProgramDto TemplateProgramDto { get; }
        public string UserId { get; }
        public CreateTemplateProgramCommand(TemplateProgramDto templateProgramDto, string userId)
        {
            TemplateProgramDto = templateProgramDto;
            UserId = userId;
        }
    }

    public class CreateTemplateProgramCommandValidator : AbstractValidator<CreateTemplateProgramCommand>
    {
        public CreateTemplateProgramCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage(ValidationConstants.NOT_EMPTY);
            RuleFor(x => x.TemplateProgramDto.Name).NotEmpty().WithMessage(ValidationConstants.NOT_EMPTY);
            RuleFor(x => x.TemplateProgramDto.Description).NotEmpty().WithMessage(ValidationConstants.NOT_EMPTY);
            RuleFor(x => x.TemplateProgramDto.WeightProgressionType).NotEmpty().WithMessage(ValidationConstants.NOT_EMPTY);
            RuleFor(x => x.TemplateProgramDto.TemplateType).NotEmpty().WithMessage(ValidationConstants.NOT_EMPTY);
            RuleFor(x => x.TemplateProgramDto.Difficulty).NotEmpty().WithMessage(ValidationConstants.NOT_EMPTY);
            RuleFor(x => x.TemplateProgramDto.NoOfDaysPerWeek).GreaterThan(0).WithMessage(ValidationConstants.GREATER_THAN);
            RuleFor(x => x.TemplateProgramDto.NoOfWeeks).GreaterThan(0).WithMessage(ValidationConstants.GREATER_THAN);
        }
    }

    public class CreateTemplateProgramCommandHandler : IRequestHandler<CreateTemplateProgramCommand, OneOf<TemplateProgramDto, UserNotFound, TemplateProgramNameAlreadyExists>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public CreateTemplateProgramCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OneOf<TemplateProgramDto, UserNotFound, TemplateProgramNameAlreadyExists>> Handle(CreateTemplateProgramCommand request, CancellationToken cancellationToken)
        {
            var isUserAdmin = await _context.User.AsNoTracking().AnyAsync(x => x.Id == request.UserId && x.MemberStatusId >= 2, cancellationToken: cancellationToken);

            if (!isUserAdmin)
            {
                return new UserNotFound();
            }

            var isTaken = await _context.Set<TemplateProgram>()
                .AsNoTracking()
                .AnyAsync(x => x.Name == request.TemplateProgramDto.Name, cancellationToken: cancellationToken);
            
            if (isTaken)
            {
                return new TemplateProgramNameAlreadyExists();
            }

            var template = _mapper.Map<TemplateProgram>(request.TemplateProgramDto);
            await _context.TemplateProgram.AddAsync(template, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
            return request.TemplateProgramDto;
        }
    }
}