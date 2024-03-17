using AutoSalon.Application;       // AddApplication |ishlashi uchun
using AutoSalon.Infrastructure;    // AddInfrastructure |ishlashi uchun

namespace AutoSalon.Api
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
            builder.Services.AddApplication();                              // Extension Methodni Program.cs da chaqirish
            builder.Services.AddInfrastructure(builder.Configuration);      // Extension Methodni Program.cs da chaqirish

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
