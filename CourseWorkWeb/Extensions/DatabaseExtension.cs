using CourseWorkWeb.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace CourseWorkWeb.Extensions
{
    public static class DatabaseExtension
    {
        public static IHostBuilder UseDatabase(this IHostBuilder hostBuilder)
        {
            return hostBuilder.ConfigureServices((hostingContext, services) =>
            {
                services.AddDbContext<MedicineDataContext>(options =>
                    options.UseSqlServer(hostingContext.Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("CourseWorkWeb")));
            });
        }
    }
}
