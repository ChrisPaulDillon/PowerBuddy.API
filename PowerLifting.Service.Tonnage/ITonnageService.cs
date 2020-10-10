using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PowerLifting.Data.Entities;

namespace PowerLifting.Service.Tonnages
{
    public interface  ITonnageService
    {
        public Task<IEnumerable<TonnageDay>> CreateTonnageBreakdownForDay(int programLogId, int programLogDayId, string userId);
    }
}
