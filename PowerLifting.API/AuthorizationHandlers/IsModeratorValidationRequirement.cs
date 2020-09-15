using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace PowerLifting.API.AuthorizationHandlers
{
    public class IsModeratorValidationRequirement : IAuthorizationRequirement
    {
        public IsModeratorValidationRequirement()
        {
        }
    }
}
