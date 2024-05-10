using CourseWorkWeb.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace CourseWorkWeb.Extensions
{
    public static class MediatrExtension
    {
        public static IHostBuilder UseMediatR(this IHostBuilder hostBuilder)
        {
            return hostBuilder.ConfigureServices((hostingContext, services) =>
            {
                services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly));
            });
        }
    }
}
