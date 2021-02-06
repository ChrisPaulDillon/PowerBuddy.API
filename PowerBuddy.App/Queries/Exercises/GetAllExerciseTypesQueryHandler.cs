using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PowerBuddy.App.Repositories.Exercises;
using PowerBuddy.Data.Dtos.Exercises;

namespace PowerBuddy.App.Queries.Exercises
{
    public class GetAllExerciseTypesQuery : IRequest<IEnumerable<ExerciseTypeDto>>
    {
    }

    internal class GetAllExerciseTypesQueryHandler : IRequestHandler<GetAllExerciseTypesQuery, IEnumerable<ExerciseTypeDto>>
    {
        private readonly IExerciseRepository _exerciseRepo;

        public GetAllExerciseTypesQueryHandler(IExerciseRepository exerciseRepo)
        {
            _exerciseRepo = exerciseRepo;
        }

        public async Task<IEnumerable<ExerciseTypeDto>> Handle(GetAllExerciseTypesQuery request, CancellationToken cancellationToken)
        {
            return await _exerciseRepo.GetAllExerciseTypes();
        }
    }
}
