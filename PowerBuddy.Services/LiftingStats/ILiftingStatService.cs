using System.Collections.Generic;
using System.Threading.Tasks;
using PowerBuddy.Data.DTOs.LiftingStats;
using PowerBuddy.Data.DTOs.Templates;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.Services.LiftingStats
{
    public interface ILiftingStatService
    {
        void CreateLiftingStatAudit(int liftingStatId, int exerciseId, int repRange, decimal weight, string userId);

        IEnumerable<TemplateWeightInputDTO> CalculateNewWeightInput(IEnumerable<TemplateWeightInputDTO> weightInputs, Dictionary<int, decimal> weightIncrements);

        Task<IEnumerable<LiftingStatAudit>> GetPersonalBestsForRepRangeAndExercise(IList<int> repRanges, int exerciseId, string userId);

        Task<IEnumerable<LiftingStatAuditDTO>> GetTopLiftingStatForExercise(int exerciseId, string userId);

        Task<IEnumerable<LiftingStatAuditDTO>> GetTopLiftingStatCollection(string userId);
    }
}
