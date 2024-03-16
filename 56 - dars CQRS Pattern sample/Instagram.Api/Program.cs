using Instagram.Application;                        // AddApplication |ishlashi uchun
using Instagram.Infrastructure;                     // AddInfrastructure |ishlashi uchun

namespace Instagram.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddApplication();                              // Dependcy Injection qoshish
            builder.Services.AddInfrastructure(builder.Configuration);      // Dependcy Injection qoshish


            var app = builder.Build();

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
