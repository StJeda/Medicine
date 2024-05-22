using CourseWorkWeb.DAL.Interfaces;
using CourseWorkWeb.DAL.Repositories;
using CourseWorkWeb.Models.Entity.Auth;
using CourseWorkWeb.Models.Entity.Medicines;
using Microsoft.Extensions.DependencyInjection;

namespace CourseWorkWeb.Extensions
{
    public static class RepositoriesExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPharmacyRepository, PharmacyRepository>();
            services.AddScoped<IPharmacistRepository, PharmacistRepository>();
            services.AddScoped<IMedicineRepository,MedicineRepository>();
            services.AddScoped<IOrderRepository,OrderRepository>();
            services.AddScoped<IDiseaseRepository,DiseaseRepository>();
            services.AddScoped<IRoleRepository,RoleRepository>();
            services.AddScoped<IAggregateRepository<Medicine>, AggregateRepository<Medicine>>();
            services.AddScoped<IAggregateRepository<Account>, AggregateRepository<Account>>();
            return services;
        }
    }
}
