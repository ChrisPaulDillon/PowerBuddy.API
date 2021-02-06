using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OneOf;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.DTOs.Templates;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Models.Account;
using PowerBuddy.Data.Models.TemplatePrograms;

namespace PowerBuddy.App.Commands.TemplatePrograms
{
    public class CreateTemplateProgramCommand : IRequest<OneOf<TemplateProgramDTO, UserNotFound, TemplateProgramNameAlreadyExists>>
    {
        public TemplateProgramDTO TemplateProgramDTO { get; }
        public string UserId { get; }
        public CreateTemplateProgramCommand(TemplateProgramDTO templateProgramDTO, string userId)
        {
            TemplateProgramDTO = templateProgramDTO;
            UserId = userId;
        }
    }

    public class CreateTemplateProgramCommandValidator : AbstractValidator<CreateTemplateProgramCommand>
    {
        public CreateTemplateProgramCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.TemplateProgramDTO.Name).NotNull().NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.TemplateProgramDTO.Description).NotNull().NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.TemplateProgramDTO.WeightProgressionType).NotNull().NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.TemplateProgramDTO.TemplateType).NotNull().NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.TemplateProgramDTO.Difficulty).NotNull().NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.TemplateProgramDTO.NoOfDaysPerWeek).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than 0.");
            RuleFor(x => x.TemplateProgramDTO.NoOfWeeks).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than 0.");
        }
    }

    public class CreateTemplateProgramCommandHandler : IRequestHandler<CreateTemplateProgramCommand, OneOf<TemplateProgramDTO, UserNotFound, TemplateProgramNameAlreadyExists>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public CreateTemplateProgramCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OneOf<TemplateProgramDTO, UserNotFound, TemplateProgramNameAlreadyExists>> Handle(CreateTemplateProgramCommand request, CancellationToken cancellationToken)
        {
            var isUserAdmin = await _context.User.AsNoTracking().AnyAsync(x => x.Id == request.UserId && x.MemberStatusId >= 2, cancellationToken: cancellationToken);

            if (!isUserAdmin)
            {
                return new UserNotFound();
            }

            var isTaken = await _context.Set<TemplateProgram>()
                .AsNoTracking()
                .AnyAsync(x => x.Name == request.TemplateProgramDTO.Name, cancellationToken: cancellationToken);
            
            if (isTaken)
            {
                return new TemplateProgramNameAlreadyExists();
            }

            var template = _mapper.Map<TemplateProgram>(request.TemplateProgramDTO);
            _context.TemplateProgram.Add(template);

            await _context.SaveChangesAsync(cancellationToken);
            return request.TemplateProgramDTO;
        }
    }
}