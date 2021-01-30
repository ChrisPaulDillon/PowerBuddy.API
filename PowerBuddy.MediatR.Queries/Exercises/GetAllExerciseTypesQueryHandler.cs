using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PowerBuddy.Data.DTOs.Exercises;
using PowerBuddy.Repositories.Exercises;

namespace PowerBuddy.MediatR.Queries.Exercises
{
    public class GetAllExerciseTypesQuery : IRequest<IEnumerable<ExerciseTypeDTO>>
    {
    }

    internal class GetAllExerciseTypesQueryHandler : IRequestHandler<GetAllExerciseTypesQuery, IEnumerable<ExerciseTypeDTO>>
    {
        private readonly IExerciseRepository _exerciseRepo;

        public GetAllExerciseTypesQueryHandler(IExerciseRepository exerciseRepo)
        {
            _exerciseRepo = exerciseRepo;
        }

        public async Task<IEnumerable<ExerciseTypeDTO>> Handle(GetAllExerciseTypesQuery request, CancellationToken cancellationToken)
        {
            return await _exerciseRepo.GetAllExerciseTypes();
        }
    }
}
