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
        public static string FindUserId(this ClaimsPrincipal claimsPrincipal)
        {
            try
            {
                var userId = claimsPrincipal.FindFirstValue("UserID");
                return userId;
            }
            catch (Exception ex) when (
                ex is ArgumentNullException
                || ex is FormatException
                || ex is OverflowException
                || ex is InvalidOperationException)
            {
                return "";
            }
        }
    }
}
