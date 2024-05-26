using Microsoft.AspNetCore.Http;

namespace CourseWorkWeb.Core.Auth
{
    public static class Access
    {
        public static bool HasPermission(HttpContext httpContext, string permission)
        {
            var user = httpContext.User;
            var hasPermission = user.Claims.Any(c => c.Type == permission);

            return hasPermission;
        }
    }
}
