using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using PowerBuddy.API.Extensions;
using PowerBuddy.Services.Account;

namespace PowerBuddy.API.AuthorizationHandlers
{
    public class IsValidUserAuthorizationHandler : AuthorizationHandler<IsValidUserValidationRequirement>
    {
        private readonly IAccountService _accountService;
        private readonly ILogger<IsValidUserValidationRequirement> _logger;

        public IsValidUserAuthorizationHandler(IAccountService accountService, ILogger<IsValidUserValidationRequirement> logger)
        {
            _accountService = accountService;
            _logger = logger;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, IsValidUserValidationRequirement requirement)
        {
            var userId = context.User.FindUserId();

            if (userId == null)
            {
                context.Fail();
            }

            if (await _accountService.DoesUserExist(userId))
            {
                context.Succeed(requirement);
            }

            context.Fail();
        }
    }
}