using CourseWorkWeb.Core.Auth;
using CourseWorkWeb.DAL.Context;
using CourseWorkWeb.DAL.Jwt;
using Microsoft.EntityFrameworkCore;

namespace CourseWorkWeb.Extensions
{
    public static class JwtExtension
    {
        public static IHostBuilder UseJwt(this IHostBuilder hostBuilder)
        {
            return hostBuilder.ConfigureServices((hostingContext, services) =>
            {
                services.AddScoped<IPasswordHasher, PasswordHasher>();
                services.AddScoped<IJwtProvider, JwtProvider>();
            });
        }
    }
}
