using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PowerBuddy.App.Repositories.Exercises;
using PowerBuddy.Data.DTOs.Exercises;

namespace PowerBuddy.App.Queries.Exercises
{
    public class GetAllExercisesQuery : IRequest<IEnumerable<ExerciseDTO>>
    {

    }

    internal class GetAllExercisesQueryHandler : IRequestHandler<GetAllExercisesQuery, IEnumerable<ExerciseDTO>>
    {
        private readonly IExerciseRepository _exerciseRepo;

        public GetAllExercisesQueryHandler(IExerciseRepository exerciseRepo)
        {
            _exerciseRepo = exerciseRepo;
        }

        public async Task<IEnumerable<ExerciseDTO>> Handle(GetAllExercisesQuery request, CancellationToken cancellationToken)
        {
            return await _exerciseRepo.GetAllExercises();
        }
    }
}
