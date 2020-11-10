using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data;

namespace PowerLifting.MediatR.TemplatePrograms.Commands.Admin
{
    public class CreateAllTemplateExerciseCollectionForTemplateCommand : IRequest<bool>
    {
        public string UserId { get; }

        public CreateAllTemplateExerciseCollectionForTemplateCommand(string userId)
        {
            UserId = userId;
        }
    }

    public class CreateAllTemplateExerciseCollectionForTemplateCommandHandler : IRequestHandler<CreateAllTemplateExerciseCollectionForTemplateCommand, bool>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateAllTemplateExerciseCollectionForTemplateCommandHandler(PowerLiftingContext context, IMapper mapper, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<bool> Handle(CreateAllTemplateExerciseCollectionForTemplateCommand request, CancellationToken cancellationToken)
        {
            var templateProgramIds = await _context.TemplateProgram.Select(x => x.TemplateProgramId).ToListAsync(cancellationToken: cancellationToken);

            foreach (var templateProgramId in templateProgramIds)
            {
                await _mediator.Send(new CreateTemplateExerciseCollectionForTemplateCommand(templateProgramId, request.UserId), cancellationToken).ConfigureAwait(false);
            }

            var modifiedRows = await _context.SaveChangesAsync(cancellationToken);
            return modifiedRows > 0;
        }
    }
}