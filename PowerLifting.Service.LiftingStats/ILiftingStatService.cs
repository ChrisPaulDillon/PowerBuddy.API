using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PowerLifting.Service.LiftingStats
{
    public interface ILiftingStatService
    {
        void CreateLiftingStatAudit(int liftingStatId, int exerciseId, int repRange, decimal weight, string userId);
    }
}
