using EFCoreSampleApi.Persistance;          // ApplicationDbContext |ishlashi uchun
using EFCoreSampleApi.Repositories;         // IPersonRepository, PersonRepository |oshlashi uchun
using Microsoft.EntityFrameworkCore;        // useNpgSql |ishlashi uchun

namespace EFCoreSampleApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IPersonRepository, PersonRepository>();  // Dependency injection qilish
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration["ConnectionStrings:Default"]);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
