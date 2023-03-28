using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace CarClubWebApp
{
    public static class ClaimsPrincipleExtension
    {
        public static string GetUserId(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
