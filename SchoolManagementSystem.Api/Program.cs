using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using SchoolManagementSystem.Api.Middleware;
using SchoolManagementSystem.Core;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Infrastructure;
using SchoolManagementSystem.Services;
using System.Globalization;
namespace SchoolManagementSystem.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSingleton<SharedResource>();
            #region Swagger Registration
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "School Management System",
                    Description = "ASP.NET Core Web API"
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
            #endregion
            #region Dependency Injection
            builder.Services.AddInfrastructurefDependencyInjection(builder.Configuration);
            builder.Services.AddServiceDependencyInjection();
            builder.Services.AddCoreDependencyInjection();
            builder.Services.AddAuthenticationServices(builder.Configuration);
            #endregion




            var app = builder.Build();

            app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value); // for localization

            #region Middle ware
            app.Use(async (context, next) =>
            {
                var culture = context.Request.Query["culture"]; // Read culture from query
                if (!string.IsNullOrWhiteSpace(culture))
                {
                    CultureInfo cultureInfo = new CultureInfo(culture);
                    CultureInfo.CurrentCulture = cultureInfo;
                    CultureInfo.CurrentUICulture = cultureInfo;
                }
                await next();
            });
            #endregion

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseMiddleware<ExceptionHandlingMiddleware>(); //  custom middleware for error handling
            app.UseStaticFiles();
            app.UseCors("MyPolicy");
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
