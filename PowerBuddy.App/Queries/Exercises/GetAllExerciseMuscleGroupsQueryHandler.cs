using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PowerBuddy.App.Repositories.Exercises;
using PowerBuddy.Data.Dtos.Exercises;

namespace PowerBuddy.App.Queries.Exercises
{
    public class GetAllExerciseMuscleGroupsQuery : IRequest<IEnumerable<ExerciseMuscleGroupDto>>
    {
 
    }

    internal class GetAllExerciseMuscleGroupsQueryHandler : IRequestHandler<GetAllExerciseMuscleGroupsQuery, IEnumerable<ExerciseMuscleGroupDto>>
    {
        private readonly IExerciseRepository _exerciseRepo;

        public GetAllExerciseMuscleGroupsQueryHandler(IExerciseRepository exerciseRepo)
        {
            _exerciseRepo = exerciseRepo;
        }

        public async Task<IEnumerable<ExerciseMuscleGroupDto>> Handle(GetAllExerciseMuscleGroupsQuery request, CancellationToken cancellationToken)
        {
            return await _exerciseRepo.GetAllExerciseMuscleGroups();
        }
    }
}
