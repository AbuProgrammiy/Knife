using MediatR;                                              // AddMediatR |ishlashi uchun
using Microsoft.Extensions.DependencyInjection;             // IServiceCollection|ishlashi uchun
using System.Reflection;                                    // Assembly |ishlashi uchun 

namespace Instagram.Application
{
    public static class DependcyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // AddMediatR togri ishlashi uchun:  MediatR.Extensions.Microsoft.DependencyInjection   kochirish kerak  va ikkalsi 11.0.0 versiyada bolmogi lozim
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }

    }
}
