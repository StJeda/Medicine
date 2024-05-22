namespace CourseWorkWeb.Extensions
{
    public static class AuthorizationExtension
    {
        public static IHostBuilder UseAuthorize(this IHostBuilder hostBuilder)
        {
            return hostBuilder.ConfigureServices((hostingContext, services) =>
            {
                services.AddAuthorization(options =>
                {
                    options.AddPolicy("CabinetPermission", policy =>
                    {
                        policy.RequireAssertion(context =>
                            context.User.HasClaim(claim =>
                                claim.Type == "Permission" && claim.Value == "CABINET"));
                    });
                });
            });
        }
    }
}
