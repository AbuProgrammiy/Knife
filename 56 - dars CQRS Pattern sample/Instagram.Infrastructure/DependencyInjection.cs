using Instagram.Application.Abstractions;                   // IApplicationDbContext |ishlashi uchun    
using Instagram.Infrastructure.Persistance;                 // ApplicationDbContext |ishlashi uchun
using Microsoft.EntityFrameworkCore;                        // UseNpgsql |ishlashi uchun
using Microsoft.Extensions.Configuration;                   // IConfiguration |ishlashi uchun   
using Microsoft.Extensions.DependencyInjection;             // IServiceCollection |ishlashi uchun

namespace Instagram.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration config)
        {
            services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
            {
                options.UseNpgsql(config["ConnectionStrings:DefaultConnection"]);
            });

            return services;    
        }
    }
}
