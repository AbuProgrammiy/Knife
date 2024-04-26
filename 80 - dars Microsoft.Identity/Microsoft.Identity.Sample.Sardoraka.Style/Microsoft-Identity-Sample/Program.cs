using Microsoft.AspNetCore.Identity;                                            // IdentityRole, AddDefaultTokenProviders |ishlashi uchun
using Microsoft.EntityFrameworkCore;                                            // UseNpgsql |ishlashi uchun
using Microsoft_Identity_Sample.Models;                                         // AppUser |ishlashi uchun             

namespace Microsoft_Identity_Sample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddDbContext<ApplicationIdentityDbContext>(options =>
            //               ^^^^^^^^^^^^ -> ApplicationIdentityDbContextni ro'yxatni o'tkazish uchun
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddIdentity<AppUser, IdentityRole>()
            //               ^^^^^^^^^^^ -> Identity to'g'ri ishlashi uchun uni ro'yxatdan otkazish kearak
                .AddEntityFrameworkStores<ApplicationIdentityDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            //  ^^^^^^^^^^^^^^^^^ -> Authenticationni Middleware qo'shish

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
