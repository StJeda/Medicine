using CourseWorkWeb.Core.CQRS_.Queries;
using CourseWorkWeb.Core.CQRSadd.IEntity;
using CourseWorkWeb.DAL.Context;
using CourseWorkWeb.DAL.Interfaces;
using CourseWorkWeb.DAL.Repositories;
using CourseWorkWeb.Extensions;
using CourseWorkWeb.Models.Entity.Medicines;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Host.UseCustomSerilog();
builder.Host.UseDatabase();
builder.Host.UseMediatR();
builder.Services.AddRepositories();
builder.Services.AddScoped<IAggregateRepository<Medicine>, AggregateRepository<Medicine>>();
builder.Services.AddTransient(typeof(IRequestHandler<GetEntitiesQuery<Medicine>, IEnumerable<Medicine>>), typeof(EntitiesQueryHandler<Medicine>));


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
