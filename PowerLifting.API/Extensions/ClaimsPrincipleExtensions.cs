using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PowerLifting.API.Extensions
{
    public static class ClaimsPrincipleExtensions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1305:Specify IFormatProvider", Justification = "Claim is not localized")]
        public static string FindUserId(this ClaimsPrincipal claimsPrincipal, string claimName)
        {
            try
            {
                var userId = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
                if (userId == null)
                {
                    userId = "194120d9-b0c5-4d41-be94-3f62d99a2f01";
                }

                return userId;
            }
            catch (Exception ex) when (
                ex is ArgumentNullException
                || ex is FormatException
                || ex is OverflowException)
            {
                return "194120d9-b0c5-4d41-be94-3f62d99a2f01";
            }
        }
    }
}
