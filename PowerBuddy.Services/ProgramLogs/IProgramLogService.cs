using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PowerBuddy.Data.DTOs.ProgramLogs;
using PowerBuddy.Data.DTOs.Templates;
using PowerBuddy.Data.Entities;
using PowerBuddy.Services.ProgramLogs.Strategies;

namespace PowerBuddy.Services.ProgramLogs
{
    public interface IProgramLogService
    {
        Task IsProgramLogAlreadyActive(DateTime startDate, DateTime endDate, string userId);

        bool IsDateOnWorkoutDay(DateTime date, Dictionary<int, string> dayOrder, int counter);

        Task<decimal> CalculateLifetimeTonnageForExercise(int exerciseId, string userId);

        Task<ProgramLogExerciseTonnage> UpdateExerciseTonnage(ProgramLogExercise programLogExercise, string userId);

        IEnumerable<ProgramLogWeek> CreateProgramLogWeeksFromTemplate(TemplateProgram template, DateTime startDate, int iteration, string userId);

        IEnumerable<ProgramLogExercise> CreateProgramLogExercisesForTemplateDay(TemplateDay templateDay, IEnumerable<TemplateWeightInputDTO> weightInputs, ICalculateRepWeight calculateRepWeight, string userId);

        ProgramLogExerciseDTO CreateRepSchemesForExercise(ProgramLogExerciseDTO programLogExercise, string userId);

        Task<IEnumerable<DateTime>> GetAllProgramLogDatesForUser(string userId);

        IEnumerable<ProgramLogRepSchemeDTO> GetHighestWeightRepSchemeForEachRepFromCollection(ICollection<ProgramLogRepSchemeDTO> repSchemes);
    }
}
