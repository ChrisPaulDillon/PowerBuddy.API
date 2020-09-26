using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PowerLifting.Data.DTOs.System;

namespace PowerLifting.Service.System
{
    public interface ISystemService
    {
        IQueryable<GenderDTO> GetAllGendersQueryable();

        IQueryable<MemberStatusDTO> GetAllMemberStatusQueryable();
    }
}
