using System.Security.Claims;

namespace InternshipAPI.Extensions
{
    public static class ClaimsExtensions
    {
        public static int GetUserId(this ClaimsPrincipal principal) =>
            int.Parse(principal.FindFirstValue(ClaimTypes.NameIdentifier)
                      ?? throw new UnauthorizedAccessException("No user id claim"));
    }
}