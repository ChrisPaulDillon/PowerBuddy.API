using System;
using PowerLifting.Persistence;
using PowerLifting.ProgramLogs.Contracts;
using PowerLifting.ProgramLogs.Repository;
using PowerLifting.Repository.ProgramLogs;

namespace PowerLifting.ProgramLogs.Service
{
    public class ProgramLogWrapper : IProgramLogWrapper
    {
        private IProgramLogRepository _programLogRepo;
        private IProgramLogWeekRepository _programLogWeekRepo;
        private IProgramLogDayRepository _programLogDayRepo;
        private IProgramLogExerciseRepository _programLogExerciseRepo;
        private IProgramLogRepSchemeRepository _programLogRepSchemeRepo;

        private PowerliftingContext _context;

        public ProgramLogWrapper(PowerliftingContext repositoryContext)
        {
            _context = repositoryContext;
        }

        public IProgramLogRepository ProgramLog
        {
            get
            {
                if (_programLogRepo == null)
                {
                    _programLogRepo = new ProgramLogRepository(_context);
                }

                return _programLogRepo;
            }
        }

        public IProgramLogWeekRepository ProgramLogWeek
        {
            get
            {
                if (_programLogWeekRepo == null)
                {
                    _programLogWeekRepo = new ProgramLogWeekRepository(_context);
                }

                return _programLogWeekRepo;
            }
        }

        public IProgramLogDayRepository ProgramLogDay
        {
            get
            {
                if (_programLogDayRepo == null)
                {
                    _programLogDayRepo = new ProgramLogDayRepository(_context);
                }

                return _programLogDayRepo;
            }
        }

        public IProgramLogExerciseRepository ProgramLogExercise
        {
            get
            {
                if (_programLogExerciseRepo == null)
                {
                    _programLogExerciseRepo = new ProgramLogExerciseRepository(_context);
                }

                return _programLogExerciseRepo;
            }
        }

        public IProgramLogRepSchemeRepository ProgramLogRepScheme
        {
            get
            {
                if (_programLogRepSchemeRepo == null)
                {
                    _programLogRepSchemeRepo = new ProgramLogRepSchemeRepository(_context);
                }

                return _programLogRepSchemeRepo;
            }
        }
    }
}
