using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PowerBuddy.App.Repositories.Exercises;
using PowerBuddy.Data.DTOs.Exercises;

namespace PowerBuddy.App.Queries.Exercises
{
    public class GetAllExerciseMuscleGroupsQuery : IRequest<IEnumerable<ExerciseMuscleGroupDTO>>
    {
 
    }

    internal class GetAllExerciseMuscleGroupsQueryHandler : IRequestHandler<GetAllExerciseMuscleGroupsQuery, IEnumerable<ExerciseMuscleGroupDTO>>
    {
        private readonly IExerciseRepository _exerciseRepo;

        public GetAllExerciseMuscleGroupsQueryHandler(IExerciseRepository exerciseRepo)
        {
            _exerciseRepo = exerciseRepo;
        }

        public async Task<IEnumerable<ExerciseMuscleGroupDTO>> Handle(GetAllExerciseMuscleGroupsQuery request, CancellationToken cancellationToken)
        {
            return await _exerciseRepo.GetAllExerciseMuscleGroups();
        }
    }
}
