using PowerLifting.Data.Entities.Tonnage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PowerLifting.Service.Tonnages
{
    public interface  ITonnageService
    {
        public Task<IEnumerable<TonnageDay>> CreateTonnageBreakdownForDay(int programLogId, int programLogDayId, string userId);
    }
}
