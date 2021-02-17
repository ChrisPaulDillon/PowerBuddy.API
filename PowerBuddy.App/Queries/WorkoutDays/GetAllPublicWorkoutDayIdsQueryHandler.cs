using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;

namespace PowerBuddy.App.Queries.WorkoutDays
{
	public class GetAllPublicWorkoutDayIdsQuery : IRequest<IEnumerable<int>>
	{
	}

	public class GetAllPublicWorkoutDayIdsQueryHandler : IRequestHandler<GetAllPublicWorkoutDayIdsQuery, IEnumerable<int>>
	{
		private readonly PowerLiftingContext _context;

		public GetAllPublicWorkoutDayIdsQueryHandler(PowerLiftingContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<int>> Handle(GetAllPublicWorkoutDayIdsQuery request, CancellationToken cancellationToken)
		{
			var workoutDayIds = await _context.WorkoutDay.Where(x => x.User.IsPublic)
				.AsNoTracking()
				.Select(x => x.WorkoutDayId)
				.ToListAsync(cancellationToken: cancellationToken);

			return workoutDayIds;
		}
	}
}