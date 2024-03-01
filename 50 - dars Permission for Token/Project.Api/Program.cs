using Project.Application.Services.AuthServices;        // IAuthService, AuthService ishlashi uchun
using Microsoft.AspNetCore.Authentication.JwtBearer;    // JwtBearerDefaults, JwtBearerEvents ishlashi uchun
using Microsoft.IdentityModel.Tokens;                   // TokenValidationParameters, SymmetricSecurityKey, SecurityTokenExpiredException ishlashi uchun
using System.Text;                                      // Encoding ishlashi uchun
using Microsoft.OpenApi.Models;                         // OpenApiInfo, OpenApiSecurityScheme, OpenApiReference, OpenApiSecurityRequirement ishalshi uchun            
using Microsoft.Extensions.DependencyInjection;                         

namespace Project.Api
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

            builder.Services.AddSwaggerGen(options =>       //Swaggerni nastroyka qilish. Swaggerda Authorization qilish uchun quluf iconcasini chiqarish uchun
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Authentication Sample", Version = "v1.0.0", Description = "Authentication Sample Simple" });

                var securityShceme = new OpenApiSecurityScheme
                {
                    Description = "Greeting Methodini ishlatish uchun Avtorizatsiya qilishingiz kerak",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };

                options.AddSecurityDefinition("Bearer", securityShceme);
                var securityRequirement = new OpenApiSecurityRequirement
                {
                    {securityShceme,new[] {"Bearer"} }
                };
                options.AddSecurityRequirement(securityRequirement);
            });




            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(  // Token Eskirgan yoki yoqlikga tekshiradi
                options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
                        ValidAudience = builder.Configuration["JWT:ValidAudence"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]!)),
                        ClockSkew = TimeSpan.Zero
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = (context) =>
                        {
                            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                            {
                                context.Response.Headers.Add("IsTokenExpired", "true");
                            }
                            return Task.CompletedTask;
                        }
                    };
                });

            builder.Services.AddScoped<IAuthService, AuthService>(); // IAuthService va AuthServiceni dependency injection qilish


            var app = builder.Build();  // ushbu codedan pasti MiddleWare lar deb ataladi

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();    // yuqoridagi AddAuthentication ishlatib qoyish -21
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
