using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using PowerLifting.API.Extensions;
using PowerLifting.Service.Account;

namespace PowerLifting.API.AuthorizationHandlers
{
    public class IsModeratorAuthorizationHandler : AuthorizationHandler<IsModeratorValidationRequirement>
    {
        private readonly IAccountService _accountService;
        private readonly ILogger<IsModeratorAuthorizationHandler> _logger;

        public IsModeratorAuthorizationHandler(IAccountService accountService, ILogger<IsModeratorAuthorizationHandler> logger)
        {
            _accountService = accountService;
            _logger = logger;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsModeratorValidationRequirement requirement)
        {
            var userId = context.User.FindUserId(ClaimTypes.NameIdentifier);

            if (_accountService.IsUserModerator(userId))
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }

            context.Fail();
            return Task.CompletedTask;
        }
    }
}