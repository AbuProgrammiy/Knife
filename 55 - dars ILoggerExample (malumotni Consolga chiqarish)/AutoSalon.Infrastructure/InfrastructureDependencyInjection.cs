using AutoSalon.Application.Abstractions.IRepositories; // ICarRepository, IWorkerRepository |ishlashi uchun
using AutoSalon.Infrastructure.Repositories;            // CarRepository, WorkerRepository |ishlashi uchun
using AutoSalon.Infrastructure.Persistance;             // AutoSalonDbContext |ishlashi uchun
using Microsoft.EntityFrameworkCore;                    // UseNpgsql |ishlashi uchun
using Microsoft.Extensions.Configuration;               // IConfiguration |ishlashi uchun
using Microsoft.Extensions.DependencyInjection;         // IServiceCollection |ishalshi uchun

namespace AutoSalon.Infrastructure
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AutoSalonDbContext>(options =>
            {
                options.UseNpgsql(config.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IWorkerRepository, WorkerRepository>();
            return services;
        }
    }
}
