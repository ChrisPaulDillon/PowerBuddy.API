using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PowerBuddy.App.Repositories.Exercises;
using PowerBuddy.Data.Dtos.Exercises;

namespace PowerBuddy.App.Queries.Exercises
{
    public class GetAllExercisesQuery : IRequest<IEnumerable<ExerciseDto>>
    {

    }

    internal class GetAllExercisesQueryHandler : IRequestHandler<GetAllExercisesQuery, IEnumerable<ExerciseDto>>
    {
        private readonly IExerciseRepository _exerciseRepo;

        public GetAllExercisesQueryHandler(IExerciseRepository exerciseRepo)
        {
            _exerciseRepo = exerciseRepo;
        }

        public async Task<IEnumerable<ExerciseDto>> Handle(GetAllExercisesQuery request, CancellationToken cancellationToken)
        {
            return await _exerciseRepo.GetAllExercises();
        }
    }
}
