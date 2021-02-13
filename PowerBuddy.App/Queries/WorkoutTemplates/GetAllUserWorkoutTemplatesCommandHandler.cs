using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.DTOs.WorkoutTemplates;
using PowerBuddy.Util;

namespace PowerBuddy.App.Queries.WorkoutTemplates
{
    public class GetAllUserWorkoutTemplatesQuery : IRequest<IEnumerable<WorkoutTemplateDto>>
    {
        public string UserId { get; }

        public GetAllUserWorkoutTemplatesQuery(string userId)
        {
            UserId = userId;
        }
    }

    public class GetAllUserWorkoutTemplatesQueryValidator : AbstractValidator<GetAllUserWorkoutTemplatesQuery>
    {
        public GetAllUserWorkoutTemplatesQueryValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage(ValidationConstants.NOT_EMPTY);
        }
    }

    public class GetAllUserWorkoutTemplatesQueryHandler : IRequestHandler<GetAllUserWorkoutTemplatesQuery, IEnumerable<WorkoutTemplateDto>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public GetAllUserWorkoutTemplatesQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<WorkoutTemplateDto>> Handle(GetAllUserWorkoutTemplatesQuery request, CancellationToken cancellationToken)
        {
            return await _context.WorkoutTemplate
                .AsNoTracking()
                .ProjectTo<WorkoutTemplateDto>(_mapper.ConfigurationProvider)
                .Where(x => x.UserId == request.UserId)
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
