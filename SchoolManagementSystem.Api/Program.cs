using Microsoft.Extensions.Options;
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
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<SharedResource>();


            #region Dependency Injection
            builder.Services.AddInfrastructurefDependencyInjection(builder.Configuration);
            builder.Services.AddServiceDependencyInjection();
            builder.Services.AddCoreDependencyInjection();
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
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
