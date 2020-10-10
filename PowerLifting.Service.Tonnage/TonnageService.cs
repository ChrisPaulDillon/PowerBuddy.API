using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.Entities;
using PowerLifting.Data.EntityFactories;
using PowerLifting.Data.Exceptions.ProgramLogs;
using PowerLifting.Service.Tonnages.Models;

namespace PowerLifting.Service.Tonnages
{
    public class TonnageService : ITonnageService
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly ITonnageFactory _tonnageFactory;

        public TonnageService(PowerLiftingContext context, IMapper mapper, ITonnageFactory tonnageFactory)
        {
            _context = context;
            _mapper = mapper;
            _tonnageFactory = tonnageFactory;
        }

        public async Task<IEnumerable<TonnageDay>> CreateTonnageBreakdownForDay(int programLogId, int programLogDayId, string userId)
        {
            var programLogDay = await _context.ProgramLogDay
                .AsNoTracking()
                .Where(x => x.ProgramLogDayId == programLogDayId)
                .ProjectTo<ProgramLogDayDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            if (programLogDay == null) throw new ProgramLogDayNotFoundException();

            var individualExercises = programLogDay.ProgramLogExercises
                .GroupBy(e => e.ExerciseId)
                .Select(x => new { ExerciseId = x.Key, Items = x.ToList()})
                .ToList();

            var tonnageList = new List<TonnageDay>();

            foreach (var logExercise in programLogDay.ProgramLogExercises)
            {
                var exerciseTonnage = logExercise.ProgramLogRepSchemes.Sum(x => TonnageHelper.CalculateTonnage(x.WeightLifted, (int) x.RepsCompleted));
                tonnageList.Add(_tonnageFactory.CreateDay(programLogId, programLogDayId, logExercise.ExerciseId, exerciseTonnage, userId));
            }

            return tonnageList;

        }
    }
}
