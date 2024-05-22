using CourseWorkWeb.DAL.Jwt;
using CourseWorkWeb.Extensions;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.Extensions.Options;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Host.UseCustomSerilog();
builder.Host.UseDatabase();
builder.Host.UseMediatR();
builder.Host.UseJwt();
builder.Host.UseAuth();
builder.Host.UseAuthorize();

builder.Services.AddRepositories();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
    Secure = CookieSecurePolicy.Always,
    HttpOnly = HttpOnlyPolicy.Always
}); 

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
