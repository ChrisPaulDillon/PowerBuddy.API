using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using PowerLifting.API.Extensions;
using PowerLifting.Data.DTOs.Users;
using PowerLifting.Service.Account;
using PowerLifting.Service.System;

namespace PowerLifting.API.GraphQL
{
    public class Query
    {
        [Authorize(AuthenticationSchemes = "Bearer")]
        [UseFirstOrDefault]
        [UseSelection]
        public IQueryable<UserDTO> Account([Service] IAccountService svc, [Service] IHttpContextAccessor accessor)
        {
            var _userId = accessor.HttpContext.User.FindUserId();
            return svc.GetAccountQueryable(_userId);
        }
    }
}
