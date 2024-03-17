using AutoSalon.Application.IServices;                  // ICarService, IWorkerService |ishlashi uchun
using AutoSalon.Application.Services;                   // CarService, WorkerService |ishlashi uchun
using Microsoft.Extensions.DependencyInjection;         // IServiceCollection |ishalshi uchun

namespace AutoSalon.Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICarService,CarService>();
            services.AddScoped<IWorkerService,WorkerService>();
            return services;
        }
    }
}
