using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PowerLifting.Data.DTOs.System;

namespace PowerLifting.Service.System
{
    public interface ISystemService
    {
        Task<IEnumerable<GenderDTO>> GetAllGenders();

        Task<IEnumerable<MemberStatusDTO>> GetAllMemberStatus();

        Task<IEnumerable<LiftingLevelDTO>> GetAllLiftingLevels();
    }
}
