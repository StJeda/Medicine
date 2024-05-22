using CourseWorkWeb.DAL.Context;
using CourseWorkWeb.DAL.Jwt;
using CourseWorkWeb.Models.Entity.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
namespace CourseWorkWeb.Extensions
{
    public static class AuthenticationExtension
    {
        public static IHostBuilder UseAuth(this IHostBuilder hostBuilder)
        {
            return hostBuilder.ConfigureServices((hostingContext, services) =>
            {
                var jwtOptions = hostingContext.Configuration
                    .GetSection(nameof(JwtOptions)).Get<JwtOptions>();

                services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey))
                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            context.Token = context.Request.Cookies["APTEKA24-COOKIES"];
                            return Task.CompletedTask;
                        }
                    };
                });
                services.AddAuthorization();
            });
        }
    }
}
