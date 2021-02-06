using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PowerBuddy.Data.Dtos.LiftingStats;
using PowerBuddy.Data.Dtos.Templates;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.App.Services.LiftingStats
{
    public interface ILiftingStatService
    {
        void CreateLiftingStatAudit(int liftingStatId, int exerciseId, int repRange, decimal weight, string userId);

        IEnumerable<TemplateWeightInputDto> CalculateNewWeightInput(IEnumerable<TemplateWeightInputDto> weightInputs, Dictionary<int, decimal> weightIncrements);

        Task<IDictionary<Tuple<int, int>, LiftingStatAudit>> GetPersonalBestsForRepRangeAndExercise(IList<int> repRanges, int exerciseId, string userId);

        Task<IEnumerable<LiftingStatAuditDto>> GetTopLiftingStatForExercise(int exerciseId, string userId);

        Task<IEnumerable<LiftingStatAuditDto>> GetTopLiftingStatCollection(string userId);
    }
}
