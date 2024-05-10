using Serilog;

namespace CourseWorkWeb.Extensions
{
    public static class SerilogExtension
    {
        public static IHostBuilder UseCustomSerilog(this IHostBuilder hostBuilder)
        {
            return hostBuilder.ConfigureServices((hostingContext, services) =>
            {
                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Information()
                    .WriteTo.Console()
                    .WriteTo.File("logs/sitelog-.txt", rollingInterval: RollingInterval.Day)
                    .CreateLogger();

                services.AddLogging(loggingBuilder =>
                {
                    loggingBuilder.ClearProviders(); 
                    loggingBuilder.AddSerilog(dispose: true); 
                });
            });
        }
    }

}
