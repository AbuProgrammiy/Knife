using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//IserviceCollection ishlashi uchun vvv
using EmailSenderApp.Application.Services;
//AddScoped ishlashi uchun vvv
using Microsoft.Extensions.DependencyInjection;

namespace EmailSenderApp.Application
{
    public static  class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ISendEmailService,SendEmailService>();
            return services;
        }
    }
}
