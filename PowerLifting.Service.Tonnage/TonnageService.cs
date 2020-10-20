using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Exceptions.ProgramLogs;
using PowerLifting.Data.Factories;

namespace PowerLifting.Service.Tonnages
{
    public class TonnageService : ITonnageService
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly IEntityFactory _entityFactory;

        public TonnageService(PowerLiftingContext context, IMapper mapper, IEntityFactory entityFactory)
        {
            _context = context;
            _mapper = mapper;
            _entityFactory = entityFactory;
        }

        public async Task<IEnumerable<TonnageDayExercise>> CreateTonnageBreakdownForDay(int programLogId, int programLogDayId, string userId)
        {
            var programLogDay = await _context.ProgramLogDay
                .AsNoTracking()
                .Where(x => x.ProgramLogDayId == programLogDayId)
                .ProjectTo<ProgramLogDayDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            if (programLogDay == null) throw new ProgramLogDayNotFoundException();

            var tonnageList = new List<TonnageDayExercise>();

            foreach (var logExercise in programLogDay.ProgramLogExercises)
            {
                var tonnageDay = await _context.TonnageDayExercise.FirstOrDefaultAsync(x => x.ProgramLogDayId == programLogDayId && x.ExerciseId == logExercise.ExerciseId);
                var exerciseTonnage = logExercise.ProgramLogRepSchemes.Sum(x => TonnageHelper.CalculateTonnage(x.WeightLifted, (int) x.RepsCompleted));
                if (tonnageDay != null)
                {
                    tonnageDay.DayTonnage = exerciseTonnage;
                    _context.TonnageDayExercise.Update(tonnageDay);
                }
                else
                {
                    var newTonnageDay = _entityFactory.CreateTonnageDayExercise(programLogId, programLogDayId, logExercise.ExerciseId, exerciseTonnage, userId);
                    tonnageList.Add(newTonnageDay);
                    _context.TonnageDayExercise.Add(newTonnageDay);
                }
            }

            await _context.SaveChangesAsync();

            return tonnageList;

        }

        public Task<IEnumerable<ProgramLogExerciseDTO>> AssignProgramLogExercisesTonnageId(IEnumerable<ProgramLogExerciseDTO> programLogExercises, IEnumerable<TonnageDayExercise> tonnageDayExercises)
        {
            foreach (var programLogExercise in programLogExercises)
            {
                var tonnageDayExerciseId = tonnageDayExercises
                    .Where(x => x.ProgramLogDayId == programLogExercise.ProgramLogDayId &&
                                x.ExerciseId == programLogExercise.ExerciseId)
                    .Select(x => x.TonnageDayExerciseId)
                    .FirstOrDefault();
            }

            return null;
        }
    }
}
